import React from "react";
import { useState } from "react";
import { Button, Form } from "react-bootstrap";
import { useSelector } from "react-redux";
import { PublishComment } from "../../APIs/PostServiceAPI";

import style from "./CreateComment.module.css";
export const CreateComment = ({ postId }) => {
    const [commentText, setCommentText] = useState("");
    const myInfo = useSelector((state) => state.myInfo);

    const onSubmit = () => {
        if (!!commentText) {
            PublishComment(myInfo?.user?.id, postId, commentText)?.then(
                (response) => {
                    console.log(response);
                    window.location.reload(true);
                }
            );
        }
    };
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
