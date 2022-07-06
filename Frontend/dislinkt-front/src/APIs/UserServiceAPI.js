import axios from "axios";

export const RegisterUser = (user) => {
    console.log(user);
    const firstname = user.firstname;
    const surname = user.surname;
    const email = user.email;
    const telephone = user.telephone;
    const gender = user.gender;
    const birthDate = user.birthDate;
    const biography = user.biography;
    const username = user.username;
    const interest = user.interest;
    const skills = user.skills;
    const password = user.password;
    const isPrivate = user.isPrivate;
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
