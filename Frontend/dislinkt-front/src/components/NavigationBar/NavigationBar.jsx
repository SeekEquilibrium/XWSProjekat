import { useEffect, useState } from "react";
import { SearchedUsers } from "../SearchedUsers/SearchedUsers";
import {
    Navbar,
    Container,
    Form,
    FormControl,
    Button,
    Modal,
    Toast,
    ToastContainer,
    Dropdown,
} from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import "./NavigationBar.css";
import { useDispatch, useSelector } from "react-redux";
import { fetchMyInfo } from "../../redux";
import { Requests } from "../Requests/Requests";

export const NavigationBar = () => {
    const dispatch = useDispatch();
    const myInfo = useSelector((state) => state.myInfo);

    const [searchClicked, setSearchClicked] = useState(false);
    const [requestsClicked, setRequestsClicked] = useState(false);
    const [firstname, setFirstname] = useState("");
    const [surname, setSurname] = useState("");
    const [username, setUsername] = useState("");
    const [showWarning, setShowWarning] = useState(false);
    const [token, setToken] = useState(null);
    const navigate = useNavigate();

    const toggleShowWarning = () => setShowWarning(!showWarning);

    useEffect(() => {
        setToken(localStorage.getItem("token"));
    }, []);

    useEffect(() => {
        console.log("TOKEN", token);
        if (token != null) {
            dispatch(fetchMyInfo());
        }
    }, [token]);

    useEffect(() => {
        setTimeout(function () {
            setShowWarning(false);
        }, 3000);
    }, [showWarning]);

    const onSearch = (event) => {
        event.preventDefault();
        if (!firstname && !surname && !username) {
            setShowWarning(true);
            return;
        }
        setSearchClicked(true);
    };

    const goToFeed = () => {
        navigate("/feed");
    };

    const goToMyProfile = () => {
        navigate(`/user/${myInfo?.user?.id}`);
    };

    const goToEdit = () => {
        navigate("/edit");
    };

    const logout = () => {
        localStorage.removeItem("token");
        window.location.reload(true);
    };

    const closeModal = () => {
        setSearchClicked(false);
    };

    return (
        <>
            <Navbar bg="light" variant="primary" expand="lg">
                <Container>
                    <Navbar.Brand href="/feed">Dislinkt</Navbar.Brand>
                    <Form className="flex-row-center" onSubmit={onSearch}>
                        <FormControl
                            type="search"
                            placeholder="Firstname"
                            className="me-2 searchbar"
                            aria-label="Search"
                            value={firstname}
                            onChange={(e) => setFirstname(e.target.value)}
                        />
                        <FormControl
                            type="search"
                            placeholder="Surname"
                            className="me-2 searchbar"
                            aria-label="Search"
                            value={surname}
                            onChange={(e) => setSurname(e.target.value)}
                        />
                        <FormControl
                            type="search"
                            placeholder="Username"
                            className="me-2 searchbar"
                            aria-label="Search"
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}
                        />
                        <Button variant="outline-success" type="submit">
                            Search
                        </Button>
                        <ToastContainer position="top-center">
                            <Toast
                                bg="warning"
                                show={showWarning}
                                onClose={toggleShowWarning}
                            >
                                <Toast.Header>
                                    <img
                                        src="holder.js/20x20?text=%20"
                                        className="rounded me-2"
                                        alt=""
                                    />
                                    <strong className="me-auto">
                                        Enter Search Query
                                    </strong>
                                </Toast.Header>
                            </Toast>
                        </ToastContainer>
                    </Form>
                    {!token ? (
                        <div className="navbar-buttons">
                            <Button
                                onClick={() => navigate("/login")}
                                variant="primary"
                            >
                                Sign In
                            </Button>{" "}
                            <Button
                                onClick={() => navigate("/registration")}
                                variant="primary"
                            >
                                Sign Up
                            </Button>{" "}
                        </div>
                    ) : (
                        <>
                            <Dropdown>
                                <Dropdown.Toggle
                                    variant="outline-primary"
                                    id="dropdown-basic"
                                >
                                    Options
                                </Dropdown.Toggle>

                                <Dropdown.Menu>
                                    <Dropdown.Item
                                        onClick={() => {
                                            goToFeed();
                                        }}
                                    >
                                        Feed
                                    </Dropdown.Item>
                                    <Dropdown.Item
                                        onClick={() => {
                                            setRequestsClicked(true);
                                        }}
                                    >
                                        Requests
                                    </Dropdown.Item>
                                    <Dropdown.Item
                                        onClick={() => goToMyProfile()}
                                    >
                                        Go to your profile
                                    </Dropdown.Item>
                                    <Dropdown.Item onClick={() => goToEdit()}>
                                        Edit profile
                                    </Dropdown.Item>
                                    <Dropdown.Item
                                        className="logout"
                                        onClick={() => logout()}
                                    >
                                        Logout
                                    </Dropdown.Item>
                                </Dropdown.Menu>
                            </Dropdown>
                            {/* <Button
                                onClick={() => logout()}
                                variant="outline-dark"
                            >
                                Log out
                            </Button>{" "} */}
                        </>
                    )}
                </Container>
            </Navbar>
            <Modal
                aria-labelledby="contained-modal-title-vcenter"
                centered
                show={searchClicked}
                onHide={() => setSearchClicked(false)}
            >
                <Modal.Header closeButton>
                    <Modal.Title>Select User</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <SearchedUsers
                        firstname={firstname}
                        surname={surname}
                        username={username}
                        closeModal={closeModal}
                    />
                </Modal.Body>
            </Modal>
            <Modal
                aria-labelledby="contained-modal-title-vcenter"
                centered
                show={requestsClicked}
                onHide={() => setRequestsClicked(false)}
            >
                <Modal.Header closeButton>
                    <Modal.Title>Requests</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Requests />
                </Modal.Body>
            </Modal>
        </>
    );
};
