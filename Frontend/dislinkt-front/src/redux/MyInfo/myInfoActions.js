import {
    FETCH_MY_INFO_REQUEST,
    FETCH_MY_INFO_SUCCESS,
    FETCH_MY_INFO_FAILURE,
} from "./myInfoTypes";
import axios from "axios";
import BaseApiClass from "../../APIs/BaseApiClass";

export const fetchMyInfoRequest = () => {
    return {
        type: FETCH_MY_INFO_REQUEST,
    };
};

export const fetchMyInfoSuccess = (user) => {
    return {
        type: FETCH_MY_INFO_SUCCESS,
        payload: user,
    };
};

export const fetchMyInfoFailure = (error) => {
    return {
        type: FETCH_MY_INFO_FAILURE,
        payload: error,
    };
};

export const fetchMyInfo = () => {
    return (dispatch) => {
        dispatch(fetchMyInfoRequest());
        axios
            .get(
                `https://localhost:5001/users/myInfo`,
                BaseApiClass.requestConfig()
            )
            .then((response) => {
                console.log(response.data);
                dispatch(fetchMyInfoSuccess(response.data));
            })
            .catch((error) => {
                const errorMsg = error.response.data.error;
                dispatch(fetchMyInfoFailure(errorMsg));
            });
    };
};
