import React, { useState } from "react";
import style from "./Post.module.css";
import profileImage from "../../assets/images/profile-image.png";
import Button from "react-bootstrap/Button";
import { CreateComment } from "../CreateComment/CreateComment";
import { Modal } from "react-bootstrap";
import { ViewComments } from "../ViewComments/ViewComments";
export const Post = () => {
    const [createCommentClick, setCreateCommentClick] = useState(false);
    const [viewCommentsClick, setViewCommentsClick] = useState(false);
    return (
        <>
            <div className={style.post}>
                <div className={style.header}>
                    <img className={style.profileImage} src={profileImage} />
                    <div className={style.firstnameSurname}>Ivan Ivanovic</div>
                    <div className={style.username}>@ivanovicivan</div>
                    <div className={style.separator}>|</div>
                    <div className={style.date}>23.05.2022</div>
                </div>
                <div className={style.postContent}>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit.
                    Doloremque, atque, placeat repellat, sed facere aliquam
                    maiores rem obcaecati minus autem delectus quasi eaque
                    dignissimos impedit iure voluptatum quos numquam
                    praesentium.
                </div>
                <div className={style.likesDislikes}>
                    <a className={style.numberOfLikesDislikes}>25 Likes</a>
                    <a className={style.numberOfLikesDislikes}>5 Dislikes</a>
                    <a
                        onClick={() => setViewCommentsClick(true)}
                        className={style.numberOfLikesDislikes}
                    >
                        2 Comments
                    </a>
                </div>
                <hr className={style.bigSeparator}></hr>
                <div className={style.buttons}>
                    <Button variant="success">Like</Button>{" "}
                    <Button variant="danger">Dislike</Button>{" "}
                    <Button
                        onClick={() => {
                            setCreateCommentClick(true);
                        }}
                        variant="outline-secondary"
                    >
                        Comment
                    </Button>{" "}
                </div>
            </div>
            <Modal
                size="lg"
                aria-labelledby="contained-modal-title-vcenter"
                centered
                show={createCommentClick}
                onHide={() => setCreateCommentClick(false)}
            >
                <Modal.Header closeButton>
                    <Modal.Title>Write a comment...</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <CreateComment />
                </Modal.Body>
            </Modal>
            <Modal
                size="lg"
                aria-labelledby="contained-modal-title-vcenter"
                centered
                show={viewCommentsClick}
                onHide={() => setViewCommentsClick(false)}
            >
                <Modal.Header closeButton>
                    <Modal.Title>Comments</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <ViewComments />
                </Modal.Body>
            </Modal>
        </>
    );
};
