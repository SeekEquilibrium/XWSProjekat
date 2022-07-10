import axios from "axios";

export const PublishPost = async (userId, text) => {
    return axios.post(`https://localhost:5005/posts`, {
        userId,
        text,
    });
};

export const GetUserPosts = async (userId) => {
    return axios.get(`https://localhost:5005/posts/userPosts?userId=${userId}`);
};

export const GetFeedPosts = async (userId) => {
    return axios.get(`https://localhost:5005/posts/feed?userId=${userId}`);
};

export const PublishComment = async (userId, postId, text) => {
    return axios.post(`https://localhost:5005/posts/comment`, {
        postId,
        userId,
        text,
    });
};

export const LikePost = async (postId, userId) => {
    return axios.post(`https://localhost:5005/posts/likePost`, {
        postId,
        userId,
    });
};

export const DislikePost = async (postId, userId) => {
    return axios.post(`https://localhost:5005/posts/dislikePost`, {
        postId,
        userId,
    });
};
