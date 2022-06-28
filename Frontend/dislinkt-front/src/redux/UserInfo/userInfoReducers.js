import {
    FETCH_USER_INFO_REQUEST,
    FETCH_USER_INFO_SUCCESS,
    FETCH_USER_INFO_FAILURE,
} from "./userInfoTypes";

const initialState = {
    loading: false,
    user: null,
    error: "",
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case FETCH_USER_INFO_REQUEST:
            return {
                loading: true,
                user: null,
                error: "",
            };
        case FETCH_USER_INFO_SUCCESS:
            return {
                loading: false,
                user: action.payload,
                error: "",
            };
        case FETCH_USER_INFO_FAILURE:
            return {
                loading: false,
                user: null,
                error: action.payload,
            };
        default:
            return state;
    }
};

export default reducer;
