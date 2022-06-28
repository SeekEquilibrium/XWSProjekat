import React from "react";
import style from "./UserInfo.module.css";
import { useParams } from "react-router-dom";
import profileImage from "../../assets/images/profile-image.png";
export const UserInfo = () => {
    const { id } = useParams();
    return (
        <div>
            <div className={style.header}>
                <img className={style.profileImage} src={profileImage} />
                <p className={style.firstnameSurname}>Ivan Ivanovic</p>
                <p className={style.username}>@ivance</p>
                <p className={style.email}>ivanovic@gmail.com</p>
            </div>
            <div className={style.description}>
                <div className={style.interests}>
                    <p style={{ marginBottom: "0px", fontSize: "10px" }}>
                        Interests:
                    </p>
                    <p>
                        Lorem ipsum dolor, sit amet consectetur adipisicing
                        elit. Quos pariatur quibusdam ullam fugiat id
                        perspiciatis similique porro praesentium cumque,
                        consequatur quae? Praesentium esse eos reiciendis
                        obcaecati officiis explicabo vero illo.
                    </p>
                </div>
                <div className={style.biography}>
                    <p style={{ marginBottom: "0px", fontSize: "10px" }}>
                        Biography:
                    </p>
                    <p>
                        Lorem ipsum dolor sit amet consectetur adipisicing elit.
                        Excepturi sapiente itaque earum nihil. Minus nobis est
                        facere, nisi nemo ea, repellat quis suscipit ipsa
                        ratione consequatur minima adipisci veritatis
                        accusantium.Lorem ipsum dolor sit amet consectetur
                        adipisicing elit. Excepturi sapiente itaque earum nihil.
                        Minus nobis est facere, nisi nemo ea, repellat quis
                        suscipit ipsa ratione consequatur minima adipisci
                        veritatis accusantium.
                    </p>
                </div>
            </div>
            <hr></hr>
        </div>
    );
};
