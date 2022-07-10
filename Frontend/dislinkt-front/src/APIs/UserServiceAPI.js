import axios from "axios";
import BaseApiClass from "./BaseApiClass";

export const RegisterUser = async (user) => {
    return await axios.post("https://localhost:5001/auth/register", {
        firstname: user.firstname,
        surname: user.surname,
        email: user.email,
        telephone: user.telephone,
        gender: Number(user.gender),
        birthDate: user.birthDate,
        biography: user.biography,
        username: user.username,
        interest: user.interest,
        skills: [0],
        password: user.password,
        isPrivate: user.isPrivate,
    });
};

export const SignInUser = async (username, password) => {
    return await axios.post("https://localhost:5001/auth/login", {
        username,
        password,
    });
};

export const EditInfo = async (user) => {
    if (user.isPrivate === "true") {
        user.isPrivate = true;
    } else {
        user.isPrivate = false;
    }
    return await axios.put(
        "https://localhost:5001/users",
        {
            firstname: user.firstname,
            surname: user.surname,
            email: user.email,
            telephone: user.telephone,
            gender: user.gender,
            birthDate: user.birthDate,
            biography: user.biography,
            username: user.username,
            interest: user.interest,
            skills: user.skills,
            isPrivate: false,
        },
        BaseApiClass.requestConfig()
    );
};
