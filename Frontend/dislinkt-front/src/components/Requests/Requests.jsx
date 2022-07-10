import React from "react";
import { Button } from "react-bootstrap";
import style from "./Requests.module.css";
export const Requests = () => {
    return (
        <div className={style.rows}>
            <div className={style.row}>
                <div className={style.requestSender}>
                    <p className={style.fullname}>Nikola Matic</p>
                    <p className={style.username}>[@matke]</p>
                </div>
                <div className={style.buttons}>
                    <Button variant="success">Accept</Button>
                    <Button variant="danger">Delete</Button>
                </div>
            </div>
            <hr></hr>
        </div>
    );
};
