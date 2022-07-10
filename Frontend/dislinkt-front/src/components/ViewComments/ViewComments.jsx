import React from "react";
import style from "./ViewComments.module.css";
export const ViewComments = () => {
    return (
        <>
            <div>
                <div className={style.header}>
                    <p className={style.fullname}>Ivan Ivanovic</p>
                    <p className={style.username}>[@ivan]</p>
                    <p className={style.date}>26.05.2022</p>
                </div>
                <div className={style.commentText}>
                    Lorem ipsum, dolor sit amet consectetur adipisicing elit.
                    Vel perspiciatis ipsum atque excepturi sapiente error,
                    temporibus culpa animi porro neque dolorum in inventore modi
                    minus ex non nesciunt. Voluptates, inventore.
                </div>
                <hr></hr>
            </div>
        </>
    );
};
