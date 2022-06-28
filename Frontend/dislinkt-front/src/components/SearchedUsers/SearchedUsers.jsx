import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { fetchSearchedUsers } from "../../redux";

import style from "./SearchedUsers.module.css";
export const SearchedUsers = ({ firstname, surname, username }) => {
    const dispatch = useDispatch();
    const searchedUsers = useSelector((state) => state.searchedUsers);
    useEffect(() => {
        dispatch(fetchSearchedUsers(firstname, surname, username));
    }, []);
    return (
        <>
            {searchedUsers?.users?.map((user) => (
                <div className={style.row}>
                    <a className={style.row_content}>{user.username}</a>
                    <a className={style.row_content}>
                        {user.firstname} {user.surname}
                    </a>
                </div>
            ))}
        </>
    );
};
