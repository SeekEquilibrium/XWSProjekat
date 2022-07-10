import React from "react";
import { CreatePost } from "../CreatePost/CreatePost";
import style from "./Feed.module.css";
import { Post } from "../Post/Post";

export const Feed = () => {
    return (
        <div className={style.page}>
            <CreatePost />
            <hr></hr>
            <Post />
        </div>
    );
};
