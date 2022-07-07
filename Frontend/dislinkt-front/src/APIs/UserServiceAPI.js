import axios from "axios";

export const RegisterUser = (user) => {
    axios
        .post("https://localhost:5001/auth/register", {
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
        })
        .then((response) => {
            console.log(response);
        })
        .catch((error) => console.log(error));
};

export const SignInUser = async (username, password) => {
    return await axios.post("https://localhost:5001/auth/login", {
        username,
        password,
    });
};
