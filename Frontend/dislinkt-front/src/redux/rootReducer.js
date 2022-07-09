import { combineReducers } from "redux";
import searchedUsers from "./SearchedUsers/searchedUsersReducers";
import userInfo from "./UserInfo/userInfoReducers";
import myInfo from "./MyInfo/myInfoReducers";
const rootReducer = combineReducers({
    searchedUsers,
    userInfo,
    myInfo,
});

export default rootReducer;
