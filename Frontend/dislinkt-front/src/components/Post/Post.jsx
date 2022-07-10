import React, { useState } from "react";
import style from "./Post.module.css";
import profileImage from "../../assets/images/profile-image.png";
import Button from "react-bootstrap/Button";
import { CreateComment } from "../CreateComment/CreateComment";
import { Modal } from "react-bootstrap";
import { useSelector } from "react-redux";
import { ViewComments } from "../ViewComments/ViewComments";
import { LikePost, DislikePost } from "../../APIs/PostServiceAPI";
export const Post = ({ info }) => {
    const myInfo = useSelector((state) => state.myInfo);
    const [createCommentClick, setCreateCommentClick] = useState(false);
    const [viewCommentsClick, setViewCommentsClick] = useState(false);
    console.log(info);

    const likePost = () => {
        LikePost(info?.postId, myInfo?.user?.id)?.then((response) => {
            window.location.reload();
        });
    };

    const dislikePost = () => {
        DislikePost(info?.postId, myInfo?.user?.id)?.then((response) => {
            window.location.reload();
        });
    };

    return (
        <>
            <div className={style.post}>
                <div className={style.header}>
                    <img className={style.profileImage} src={profileImage} />
                    <div className={style.firstnameSurname}>
                        {info?.firstname} {info?.surname}
                    </div>
                    <div className={style.username}>@{info.username}</div>
                    <div className={style.separator}>|</div>
                    <div className={style.date}>{info.postDate}</div>
                </div>
                <div className={style.postContent}>{info.text}</div>
                <div className={style.likesDislikes}>
                    <a className={style.numberOfLikesDislikes}>
                        {info.interactions.likes} Likes
                    </a>
                    <a className={style.numberOfLikesDislikes}>
                        {info.interactions.dislikes} Dislikes
                    </a>
                    <a
                        onClick={() => setViewCommentsClick(true)}
                        className={style.numberOfLikesDislikes}
                    >
                        {info.interactions.comments.length} Comments
                    </a>
                </div>
                <hr className={style.bigSeparator}></hr>
                <div className={style.buttons}>
                    <Button onClick={() => likePost()} variant="success">
                        Like
                    </Button>{" "}
                    <Button onClick={() => dislikePost()} variant="danger">
                        Dislike
                    </Button>{" "}
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
                    <CreateComment postId={info.postId} />
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
                    <ViewComments info={info?.interactions?.comments} />
                </Modal.Body>
            </Modal>
        </>
    );
};
