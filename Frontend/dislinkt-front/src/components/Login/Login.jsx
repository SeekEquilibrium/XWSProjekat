import React from "react";
import { useState, useEffect } from "react";
import style from "./Login.module.css";
import { Form, Button, Alert } from "react-bootstrap";
import { SignInUser } from "../../APIs/UserServiceAPI";

export const Login = () => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const onSubmit = (event) => {
        event.preventDefault();
        if (!username && !password) {
            console.log("Inputs cannot be empty!");
            return;
        }
        SignInUser(username, password)
            ?.then((response) => {
                localStorage.setItem("token", response);
                window.location.reload();
            })
            .catch((error) => alert(error.message));
    };
    return (
        <div className={style.page}>
            <div className={style.title}>Sign Up</div>
            <hr></hr>
            <Form style={{ width: "100%" }} onSubmit={onSubmit}>
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

                <br></br>
                <Button variant="primary" type="submit">
                    Submit
                </Button>
            </Form>
        </div>
    );
};
