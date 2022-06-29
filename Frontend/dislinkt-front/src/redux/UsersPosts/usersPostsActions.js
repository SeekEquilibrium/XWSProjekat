import {
    FETCH_USERS_POSTS_REQUEST,
    FETCH_USERS_POSTS_SUCCESS,
    FETCH_USERS_POSTS_FAILURE,
} from "./usersPostsTypes";
import axios from "axios";

export const fetchUsersPostsRequest = () => {
    return {
        type: FETCH_USERS_POSTS_REQUEST,
    };
};

export const fetchUsersPostsSuccess = (posts) => {
    return {
        type: FETCH_USERS_POSTS_SUCCESS,
        payload: posts,
    };
};

export const fetchUsersPostsFailure = (error) => {
    return {
        type: FETCH_USERS_POSTS_FAILURE,
        payload: error,
    };
};

// export const fetchUsersPosts = (id) => {
//     return (dispatch) => {
//         dispatch(fetchUsersPostsRequest());
//         axios
//             .get(`https://localhost:5001/users/${id}`)
//             .then((response) => {
//                 dispatch(fetchUsersPostsSuccess(response.data));
//             })
//             .catch((error) => {
//                 const errorMsg = error.response.data.error;
//                 dispatch(fetchUsersPostsFailure(errorMsg));
//             });
//     };
// };
