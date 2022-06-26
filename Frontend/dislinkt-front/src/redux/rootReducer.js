import { combineReducers } from "redux";
import searchedUsers from "./SearchedUsers/searchedUsersReducers";

const rootReducer = combineReducers({
    searchedUsers,
});

export default rootReducer;
