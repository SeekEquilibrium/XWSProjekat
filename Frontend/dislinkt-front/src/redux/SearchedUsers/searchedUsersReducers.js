import {
    FETCH_SEARCHED_USERS_REQUEST,
    FETCH_SEARCHED_USERS_SUCCESS,
    FETCH_SEARCHED_USERS_FAILURE,
} from "./searchedUsersTypes";

const initialState = {
    loading: false,
    users: [],
    error: "",
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case FETCH_SEARCHED_USERS_REQUEST:
            return {
                loading: true,
                users: [],
                error: "",
            };
        case FETCH_SEARCHED_USERS_SUCCESS:
            return {
                loading: false,
                users: action.payload,
                error: "",
            };
        case FETCH_SEARCHED_USERS_FAILURE:
            return {
                loading: false,
                users: [],
                error: action.payload,
            };
        default:
            return state;
    }
};

export default reducer;
