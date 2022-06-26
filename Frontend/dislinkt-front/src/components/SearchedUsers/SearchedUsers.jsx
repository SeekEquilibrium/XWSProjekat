import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { fetchSearchedUsers } from "../../redux";

import "./SearchedUsers.css";
export const SearchedUsers = ({ firstname, surname, username }) => {
    const dispatch = useDispatch();
    const searchedUsers = useSelector((state) => state.searchedUsers);
    useEffect(() => {
        dispatch(fetchSearchedUsers(firstname, surname, username));
    }, []);
    return (
        <>
            {searchedUsers?.users?.map((user) => (
                <div className="row">
                    <a className="row-content">{user.username}</a>
                    <a className="row-content">
                        {user.firstname} {user.surname}
                    </a>
                </div>
            ))}
        </>
    );
};
