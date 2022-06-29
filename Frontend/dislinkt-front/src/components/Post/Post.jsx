import React from "react";
import style from "./Post.module.css";
import profileImage from "../../assets/images/profile-image.png";
import Button from "react-bootstrap/Button";
export const Post = () => {
    return (
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
                Doloremque, atque, placeat repellat, sed facere aliquam maiores
                rem obcaecati minus autem delectus quasi eaque dignissimos
                impedit iure voluptatum quos numquam praesentium.
            </div>
            <div className={style.likesDislikes}>
                <a className={style.numberOfLikesDislikes}>25 Likes</a>
                <a className={style.numberOfLikesDislikes}>5 Dislikes</a>
                <a className={style.numberOfLikesDislikes}>2 Comments</a>
            </div>
            <hr className={style.bigSeparator}></hr>
            <div className={style.buttons}>
                <Button variant="success">Like</Button>{" "}
                <Button variant="danger">Dislike</Button>{" "}
                <Button variant="outline-secondary">Comment</Button>{" "}
            </div>
        </div>
    );
};
