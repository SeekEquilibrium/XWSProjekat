import React from "react";
import { useState } from "react";
import { Button, Form } from "react-bootstrap";
import style from "./CreatePost.module.css";
export const CreatePost = () => {
    const [postText, setPostText] = useState("");
    const onSubmit = () => {};
    return (
        <div className={style.postCard}>
            <Form onSubmit={onSubmit}>
                <Form.Group className="mb-3">
                    <Form.Label>Create a post</Form.Label>
                    <Form.Control
                        as="textarea"
                        rows={3}
                        onChange={(e) => setPostText(e.target.value)}
                    />{" "}
                </Form.Group>
                <Button variant="primary" type="submit">
                    Submit
                </Button>
            </Form>
        </div>
    );
};
