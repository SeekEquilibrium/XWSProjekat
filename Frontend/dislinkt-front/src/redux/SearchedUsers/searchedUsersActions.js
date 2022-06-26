import {
    FETCH_SEARCHED_USERS_REQUEST,
    FETCH_SEARCHED_USERS_SUCCESS,
    FETCH_SEARCHED_USERS_FAILURE,
} from "./searchedUsersTypes";
import axios from "axios";

export const fetchSearchedUsersRequest = () => {
    return {
        type: FETCH_SEARCHED_USERS_REQUEST,
    };
};

export const fetchSearchedUsersSuccess = (users) => {
    return {
        type: FETCH_SEARCHED_USERS_SUCCESS,
        payload: users,
    };
};

export const fetchSearchedUsersFailure = (error) => {
    return {
        type: FETCH_SEARCHED_USERS_FAILURE,
        payload: error,
    };
};

export const fetchSearchedUsers = (firstname, surname, username) => {
    return (dispatch) => {
        dispatch(fetchSearchedUsersRequest());
        axios
            .get(
                `https://localhost:5001/users/search?firstname=${firstname}&surname=${surname}&username=${username}`
            )
            .then((response) => {
                dispatch(fetchSearchedUsersSuccess(response.data));
            })
            .catch((error) => {
                const errorMsg = error.response.data.error;
                dispatch(fetchSearchedUsersFailure(errorMsg));
            });
    };
};
