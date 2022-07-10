import React, { useEffect } from "react";
import { CreatePost } from "../CreatePost/CreatePost";
import style from "./Feed.module.css";
import { Post } from "../Post/Post";
import { useState } from "react";
import { GetFeedPosts } from "../../APIs/PostServiceAPI";
import { useSelector } from "react-redux";

export const Feed = () => {
    const myInfo = useSelector((state) => state.myInfo);
    const [posts, setPosts] = useState([]);
    useEffect(() => {
        GetFeedPosts(myInfo?.user?.id).then((response) => {
            setPosts(response.data);
        });
    }, [myInfo?.user]);

    const renderPosts = posts?.map((post) => {
        return <Post info={post}></Post>;
    });

    return (
        <div className={style.page}>
            <CreatePost />
            <hr></hr>
            {renderPosts}
        </div>
    );
};
