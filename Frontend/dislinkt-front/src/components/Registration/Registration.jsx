import { useState, useEffect } from "react";
import style from "./Registration.module.css";
import { Form, Button, Alert } from "react-bootstrap";
export const Registration = () => {
    const [firstname, setFirstname] = useState("");
    const [surname, setSurname] = useState("");
    const [gender, setGender] = useState(null);
    const [email, setEmail] = useState("");
    const [telephone, setTelephone] = useState("");
    const [interests, setInterests] = useState("");
    const [biography, setBiography] = useState("");
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [repeatPassword, setRepeatPassword] = useState("");

    const onSubmit = (event) => {
        event.preventDefault();
        if (
            !firstname &&
            !surname &&
            !gender &&
            !email &&
            !telephone &&
            !interests &&
            !interests &&
            !biography &&
            !username &&
            !password &&
            !repeatPassword
        ) {
        }
    };

    return (
        <div className={style.page}>
            <div className={style.title}>Sign Up</div>
            <hr></hr>
            <Form style={{ width: "100%" }} onSubmit={onSubmit}>
                <Form.Group className={style.input}>
                    <Form.Label>Firstname</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Firstname"
                        onChange={(e) => setFirstname(e.target.value)}
                    />
                </Form.Group>
                <Form.Group className={style.input}>
                    <Form.Label>Surname</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Surname"
                        onChange={(e) => setSurname(e.target.value)}
                    />
                </Form.Group>
                <Form.Group className={style.input}>
                    <Form.Label>Gender</Form.Label>
                    <Form.Select
                        aria-label="Default select example"
                        onChange={(e) => setGender(e.target.value)}
                    >
                        <option>Select Gender</option>
                        <option value="0">Male</option>
                        <option value="1">Female</option>
                    </Form.Select>
                </Form.Group>
                <Form.Group className="mb-3" controlId="formBasicEmail">
                    <Form.Label>Email address</Form.Label>
                    <Form.Control
                        type="email"
                        placeholder="Email"
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </Form.Group>
                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Telephone Number</Form.Label>
                    <Form.Control
                        type="number"
                        placeholder="Telephone Number"
                        onChange={(e) => setTelephone(e.target.value)}
                    />
                </Form.Group>
                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Interests</Form.Label>
                    <Form.Control
                        as="textarea"
                        rows={3}
                        onChange={(e) => setInterests(e.target.value)}
                    />{" "}
                </Form.Group>
                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Biography</Form.Label>
                    <Form.Control
                        as="textarea"
                        rows={5}
                        onChange={(e) => setBiography(e.target.value)}
                    />{" "}
                </Form.Group>
                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Username</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Username"
                        onChange={(e) => setUsername(e.target.value)}
                    />
                </Form.Group>
                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Password</Form.Label>
                    <Form.Control
                        type="password"
                        placeholder="Password"
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </Form.Group>
                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Repeat Password</Form.Label>
                    <Form.Control
                        type="password"
                        placeholder="Repeat Password"
                        onChange={(e) => setRepeatPassword(e.target.value)}
                    />
                </Form.Group>
                <Button variant="primary" type="submit">
                    Submit
                </Button>
            </Form>
        </div>
    );
};
