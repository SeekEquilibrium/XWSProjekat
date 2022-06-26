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
} from "react-bootstrap";
import "./NavigationBar.css";

export const NavigationBar = () => {
    const [searchClicked, setSearchClicked] = useState(false);
    const [firstname, setFirstname] = useState("");
    const [surname, setSurname] = useState("");
    const [nickname, setNickname] = useState("");
    const [showWarning, setShowWarning] = useState(false);

    const toggleShowWarning = () => setShowWarning(!showWarning);

    useEffect(() => {
        setTimeout(function () {
            setShowWarning(false);
        }, 3000);
    }, [showWarning]);

    const onSearch = (event) => {
        if (!firstname && !surname && !nickname) {
            setShowWarning(true);
            return;
        }
        setSearchClicked(true);
    };

    return (
        <>
            <Navbar bg="light" expand="lg">
                <Container>
                    <Navbar.Brand href="#home">Dislinkt</Navbar.Brand>
                    <Form className="flex-row-center">
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
                            placeholder="Nickname"
                            className="me-2 searchbar"
                            aria-label="Search"
                            value={nickname}
                            onChange={(e) => setNickname(e.target.value)}
                        />
                        <Button
                            onClick={() => onSearch()}
                            variant="outline-success"
                            type="submit"
                        >
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
                    <div className="navbar-buttons">
                        <Button variant="primary">Sign In</Button>{" "}
                        <Button variant="primary">Sign Up</Button>{" "}
                    </div>
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
                    <SearchedUsers />
                </Modal.Body>
            </Modal>
        </>
    );
};
