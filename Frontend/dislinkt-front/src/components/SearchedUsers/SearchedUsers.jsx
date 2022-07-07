import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { fetchSearchedUsers } from "../../redux";
import { useNavigate } from "react-router-dom";

import style from "./SearchedUsers.module.css";
export const SearchedUsers = ({ firstname, surname, username, closeModal }) => {
    const dispatch = useDispatch();
    const searchedUsers = useSelector((state) => state.searchedUsers);
    const navigate = useNavigate();

    useEffect(() => {
        dispatch(fetchSearchedUsers(firstname, surname, username));
    }, []);

    const onClick = (id) => {
        navigate(`/user/${id}`);
        closeModal();
    };

    return (
        <>
            {searchedUsers?.users?.map((user) => (
                <div className={style.row}>
                    <a
                        onClick={() => onClick(user.id)}
                        className={style.row_content}
                    >
                        {user.firstname} {user.surname}
                    </a>
                    <a
                        onClick={() => onClick(user.id)}
                        className={style.row_content}
                    >
                        [{user.username}]
                    </a>
                </div>
            ))}
        </>
    );
};
