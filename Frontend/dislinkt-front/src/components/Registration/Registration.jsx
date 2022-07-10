import { useState, useEffect } from "react";
import style from "./Registration.module.css";
import { Form, Button, Alert } from "react-bootstrap";
import { RegisterUser } from "../../APIs/UserServiceAPI";
import { useNavigate } from "react-router-dom";

export const Registration = () => {
    const [firstname, setFirstname] = useState("");
    const [surname, setSurname] = useState("");
    const [gender, setGender] = useState(0);
    const [email, setEmail] = useState("");
    const [birthDate, setBirthDate] = useState("");
    const [telephone, setTelephone] = useState("");
    const [interest, setInterest] = useState("");
    const [biography, setBiography] = useState("");
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [repeatPassword, setRepeatPassword] = useState("");
    const [isPrivate, setIsPrivate] = useState("");
    const navigate = useNavigate();

    const onSubmit = (event) => {
        event.preventDefault();
        if (
            !firstname &&
            !surname &&
            !gender &&
            !email &&
            !telephone &&
            !interest &&
            !birthDate &&
            !biography &&
            !username &&
            !password &&
            !repeatPassword
        ) {
            console.log("Inputs cannot be empty!");
            return;
        }
        console.log("OK");
        if (password != repeatPassword) {
            console.log("Passwords do not match!");
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
            password,
            repeatPassword,
            isPrivate,
        };
        RegisterUser(User)
            ?.then(navigate("/login"))
            ?.catch((error) => {
                alert(error.message);
            });
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
                        type="date"
                        placeholder="Birth date"
                        onChange={(e) => setBirthDate(e.target.value)}
                    />
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
                        onChange={(e) => setInterest(e.target.value)}
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
                <Form.Group className={style.input}>
                    <Form.Label>
                        Do you want your account to be private?
                    </Form.Label>
                    <Form.Select
                        aria-label="Default select example"
                        onChange={(e) => {
                            setIsPrivate(e.target.value);
                        }}
                    >
                        <option value="true">Yes</option>
                        <option value="false">No</option>
                    </Form.Select>
                </Form.Group>
                <br></br>
                <Button variant="primary" type="submit">
                    Submit
                </Button>
            </Form>
        </div>
    );
};
