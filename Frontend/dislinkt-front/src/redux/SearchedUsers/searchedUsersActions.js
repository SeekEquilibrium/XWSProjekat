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

export const fetchSearchedUsersSuccess = (comments) => {
    return {
        type: FETCH_SEARCHED_USERS_SUCCESS,
        payload: comments,
    };
};

export const fetchSearchedUsersFailure = (error) => {
    return {
        type: FETCH_SEARCHED_USERS_FAILURE,
        payload: error,
    };
};

export const fetchComments = (firstname, surname, nickname) => {
    return (dispatch) => {
        dispatch(fetchSearchedUsersRequest());
        // axios
        //     .get(
        //         `https://flowrspot-api.herokuapp.com/api/v1/sightings/${id}/comments?page=${page}`,
        //         BaseApiClass.requestConfig()
        //     )
        //     .then((response) => {
        //         const comments = response.data.comments;
        //         dispatch(fetchSearchedUsersSuccess(comments));
        //     })
        //     .catch((error) => {
        //         const errorMsg = error.response.data.error;
        //         dispatch(fetchSearchedUsersFailure(errorMsg));
        //     });
    };
};
