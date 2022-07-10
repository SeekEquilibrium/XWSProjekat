import React from "react";
import style from "./ViewComments.module.css";
export const ViewComments = ({ info }) => {
    console.log("COMMENTS", info);
    const renderComments = info?.map((comment) => {
        return (
            <>
                <div className={style.header}>
                    <p className={style.fullname}>
                        {comment?.firstname} {comment?.surname}
                    </p>
                    <p className={style.username}>[@{comment?.username}]</p>
                    <p className={style.date}>{comment?.date}</p>
                </div>
                <div className={style.commentText}>{comment?.text}</div>
                <hr></hr>
            </>
        );
    });
    return (
        <>
            <div>{renderComments}</div>
        </>
    );
};
