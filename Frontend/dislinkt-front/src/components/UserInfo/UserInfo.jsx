import { useEffect, useState } from "react";
import style from "./UserInfo.module.css";
import { useParams } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { fetchUserInfo } from "../../redux";
import profileImage from "../../assets/images/profile-image.png";
import { Post } from "../Post/Post";
import { Button } from "react-bootstrap";
export const UserInfo = () => {
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [isFollowing, setIsFollowing] = useState(false);
    const { id } = useParams();
    const dispatch = useDispatch();
    const userInfo = useSelector((state) => state.userInfo);
    useEffect(() => {
        const token = localStorage.getItem("token");
        if (!!token) {
            setIsLoggedIn(true);
        }
        dispatch(fetchUserInfo(id));
        console.log(userInfo.user);
    }, []);
    return (
        <div className={style.page}>
            <div className={style.header}>
                <img className={style.profileImage} src={profileImage} />
                <p className={style.firstnameSurname}>
                    {userInfo?.user?.firstname} {userInfo?.user?.surname}
                </p>
                <p className={style.username}>@{userInfo?.user?.username}</p>
                <p className={style.email}>{userInfo?.user?.email}</p>
                {isLoggedIn && !isFollowing ? (
                    <Button variant="primary">Follow</Button>
                ) : isLoggedIn && isFollowing ? (
                    <Button variant="outline-primary">Following</Button>
                ) : (
                    <></>
                )}
            </div>
            <div className={style.description}>
                <div className={style.interests}>
                    <p style={{ marginBottom: "0px", fontSize: "10px" }}>
                        Interests:
                    </p>
                    <p>{userInfo?.user?.interest}</p>
                </div>
                <div className={style.biography}>
                    <p style={{ marginBottom: "0px", fontSize: "10px" }}>
                        Biography:
                    </p>
                    <p>{userInfo?.user?.biography}</p>
                </div>
            </div>
            <hr></hr>
            <div className={style.postContainer}>
                <Post />
                <Post />
            </div>
        </div>
    );
};
