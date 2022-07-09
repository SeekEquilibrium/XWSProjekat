import React from "react";
import style from "./LandingPage.module.css";
import background from "../../assets/images/LandingPage.png";
export const LandingPage = () => {
    return (
        <div className={style.page}>
            <img className={style.image} src={background} />
            <h2 className={style.text1}>Welcome to</h2>
            <h1 className={style.text2}>ДИСЛИНКТ</h1>
        </div>
    );
};
