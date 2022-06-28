import { combineReducers } from "redux";
import searchedUsers from "./SearchedUsers/searchedUsersReducers";
import userInfo from "./UserInfo/userInfoReducers";

const rootReducer = combineReducers({
    searchedUsers,
    userInfo,
});

export default rootReducer;
