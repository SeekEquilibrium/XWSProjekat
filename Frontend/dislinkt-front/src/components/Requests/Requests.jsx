import React, { useEffect } from "react";
import { Button } from "react-bootstrap";
import { AcceptRequest, GetRequests } from "../../APIs/RequestServiceAPI";
import { useSelector } from "react-redux";

import style from "./Requests.module.css";
import { useState } from "react";
export const Requests = () => {
    const myInfo = useSelector((state) => state.myInfo);
    const [requestUsers, setRequestUsers] = useState([]);
    useEffect(() => {
        GetRequests(myInfo.user.id)?.then((response) => {
            setRequestUsers(response.data);
        });
    }, []);

    const acceptRequest = (sender) => {
        console.log(sender, myInfo?.user?.id);
        AcceptRequest(sender, myInfo?.user?.id)?.then((response) =>
            console.log(response)
        );
    };

    const renderRequests = requestUsers?.map((request) => {
        return (
            <>
                <div className={style.row}>
                    <div className={style.requestSender}>
                        <p className={style.fullname}>
                            {request.firstname} {request.surname}
                        </p>
                        <p className={style.username}>[@{request.username}]</p>
                    </div>
                    <div className={style.buttons}>
                        <Button
                            onClick={() => {
                                acceptRequest(request.id);
                            }}
                            variant="success"
                        >
                            Accept
                        </Button>
                        <Button variant="danger">Delete</Button>
                    </div>
                </div>
                <hr></hr>
            </>
        );
    });

    return <div className={style.rows}>{renderRequests}</div>;
};
