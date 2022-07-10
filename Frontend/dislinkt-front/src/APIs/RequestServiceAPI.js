import axios from "axios";

export const GetRequests = async (id) => {
    return axios.get(`https://localhost:5001/requests/${id}`);
};

export const AcceptRequest = async (sender, reciever) => {
    return axios.post(
        `https://localhost:5001/requests/confirm?sender=${sender}&reciever=${reciever}`
    );
};
