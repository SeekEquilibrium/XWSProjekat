import { useState, useEffect } from "react";
import { Form, Button, Alert } from "react-bootstrap";
import { EditInfo, FetchEditInfo } from "../../APIs/UserServiceAPI";
import { useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";

import style from "./EditProfile.module.css";

export const EditProfile = () => {
    const myInfo = useSelector((state) => state.myInfo);

    const [firstname, setFirstname] = useState("");
    const [surname, setSurname] = useState("");
    const [gender, setGender] = useState(0);
    const [email, setEmail] = useState("");
    const [birthDate, setBirthDate] = useState("");
    const [telephone, setTelephone] = useState("");
    const [interest, setInterest] = useState("");
    const [biography, setBiography] = useState("");
    const [username, setUsername] = useState("");
    const [isPrivate, setIsPrivate] = useState(true);
    const [skills, setSkills] = useState([]);
    const navigate = useNavigate();

    const convertUnixToDate = (unix_time) => {
        const a = new Date(unix_time);
        var months = [
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun",
            "Jul",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec",
        ];

        return `${a.getFullYear()}-${months[a.getMonth()]}-${a.getDate()}`;
    };
    useEffect(() => {
        setFirstname(myInfo?.user?.firstname);
        setSurname(myInfo?.user?.surname);
        setGender(myInfo?.user?.gender);
        setEmail(myInfo?.user?.email);
        setBirthDate(myInfo?.user?.birthDate);
        setTelephone(myInfo?.user?.telephone);
        setInterest(myInfo?.user?.interest);
        setBiography(myInfo?.user?.biography);
        setUsername(myInfo?.user?.username);
        setIsPrivate(myInfo?.user?.isPrivate);
        setSkills(myInfo?.user?.skills);
    }, [myInfo?.user]);

    const onSubmit = (event) => {
        event.preventDefault();
        if (
            !firstname &&
            !surname &&
            !gender &&
            !email &&
            !telephone &&
            !interest &&
            !biography &&
            !username
        ) {
            console.log("Inputs cannot be empty!");
            return;
        }

        const User = {
            firstname,
            surname,
            gender,
            email,
            telephone,
            interest,
            birthDate,
            biography,
            username,
            isPrivate,
            skills,
        };
        console.log(User);
        EditInfo(User)
            .then((response) => {
                console.log(response);
            })
            .catch((error) => {
                console.log(error);
            });
    };

    const cancle = () => {
        navigate("/");
    };
    return (
        <div className={style.page}>
            <div className={style.title}>Edit your profile</div>
            <hr></hr>
            <Form style={{ width: "100%" }} onSubmit={onSubmit}>
                <Form.Group className={style.input}>
                    <Form.Label>Firstname</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Firstname"
                        value={firstname}
                        onChange={(e) => setFirstname(e.target.value)}
                    />
                </Form.Group>
                <Form.Group className={style.input}>
                    <Form.Label>Surname</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Surname"
                        value={surname}
                        onChange={(e) => setSurname(e.target.value)}
                    />
                </Form.Group>
                <Form.Group className={style.input}>
                    <Form.Label>Gender</Form.Label>
                    <Form.Select
                        aria-label="Default select example"
                        value={gender}
                        onChange={(e) => setGender(e.target.value)}
                    >
                        <option value="0">Male</option>
                        <option value="1">Female</option>
                    </Form.Select>
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicEmail">
                    <Form.Label>Email address</Form.Label>
                    <Form.Control
                        type="email"
                        placeholder="Email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </Form.Group>
                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Telephone Number</Form.Label>
                    <Form.Control
                        type="number"
                        placeholder="Telephone Number"
                        value={telephone}
                        onChange={(e) => setTelephone(e.target.value)}
                    />
                </Form.Group>
                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Interests</Form.Label>
                    <Form.Control
                        as="textarea"
                        rows={3}
                        value={interest}
                        onChange={(e) => setInterest(e.target.value)}
                    />{" "}
                </Form.Group>
                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Biography</Form.Label>
                    <Form.Control
                        as="textarea"
                        rows={5}
                        value={biography}
                        onChange={(e) => setBiography(e.target.value)}
                    />{" "}
                </Form.Group>
                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Username</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                    />
                </Form.Group>
                <Form.Group className={style.input}>
                    <Form.Label>
                        Do you want your account to be private?
                    </Form.Label>
                    <Form.Select
                        aria-label="Default select example"
                        value={isPrivate}
                        onChange={(e) => setIsPrivate(e.target.value)}
                    >
                        <option value="true">Yes</option>
                        <option value="false">No</option>
                    </Form.Select>
                </Form.Group>
                <br></br>
                <div className={style.footer}>
                    <Button
                        onClick={() => cancle()}
                        variant="danger"
                        type="button"
                    >
                        Cancle
                    </Button>
                    <Button variant="success" type="submit">
                        Save changes
                    </Button>
                </div>
            </Form>
        </div>
    );
};
