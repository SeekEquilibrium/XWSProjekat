import {
    FETCH_USER_INFO_REQUEST,
    FETCH_USER_INFO_SUCCESS,
    FETCH_USER_INFO_FAILURE,
} from "./userInfoTypes";
import axios from "axios";

export const fetchUserInfoRequest = () => {
    return {
        type: FETCH_USER_INFO_REQUEST,
    };
};

export const fetchUserInfoSuccess = (users) => {
    return {
        type: FETCH_USER_INFO_SUCCESS,
        payload: users,
    };
};

export const fetchUserInfoFailure = (error) => {
    return {
        type: FETCH_USER_INFO_FAILURE,
        payload: error,
    };
};

export const fetchUserInfo = (id) => {
    return (dispatch) => {
        dispatch(fetchUserInfoRequest());
        axios
            .get(`https://localhost:5001/users/${id}`)
            .then((response) => {
                dispatch(fetchUserInfoSuccess(response.data));
            })
            .catch((error) => {
                const errorMsg = error.response.data.error;
                dispatch(fetchUserInfoFailure(errorMsg));
            });
    };
};
