import axios from "axios";

export const PublishPost = async (userId, text) => {
    return axios.post(`https://localhost:5005/posts`, {
        userId,
        text,
    });
};
