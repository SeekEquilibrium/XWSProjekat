import React from "react";
import { useState } from "react";
import { Button, Form } from "react-bootstrap";
import style from "./CreateComment.module.css";
export const CreateComment = () => {
    const [commentText, setCommentText] = useState("");

    const onSubmit = () => {};

    return (
        <div>
            <Form onSubmit={onSubmit}>
                <Form.Group className="mb-3">
                    <Form.Control
                        as="textarea"
                        rows={3}
                        onChange={(e) => setCommentText(e.target.value)}
                    />{" "}
                </Form.Group>
                <Button variant="primary" type="submit">
                    Submit
                </Button>
            </Form>
        </div>
    );
};
