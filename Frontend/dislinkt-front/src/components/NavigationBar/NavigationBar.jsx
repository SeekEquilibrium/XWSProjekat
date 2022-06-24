import React from "react";
import "./NavigationBar.css";

export const NavigationBar = () => {
    return (
        <nav className="navbar navbar-expand-lg bg-light">
            <div className="container-fluid">
                <a className="navbar-brand" href="#">
                    Dislinkt
                </a>
                <div className="searchbar flex-row-center">
                    <form className="flex-row-center">
                        <input
                            class="form-control me-2"
                            type="search"
                            placeholder="Firstname"
                            aria-label="Search"
                        ></input>
                        <input
                            class="form-control me-2"
                            type="search"
                            placeholder="Surname"
                            aria-label="Search"
                        ></input>
                        <input
                            class="form-control me-2"
                            type="search"
                            placeholder="Username"
                            aria-label="Search"
                        ></input>
                        <button
                            className="btn btn-outline-primary"
                            type="submit"
                        >
                            Search
                        </button>
                    </form>
                </div>
                <div className="navbar-buttons flex-row-center">
                    <button className="btn btn-primary" type="button">
                        Sign In
                    </button>
                    <button className="btn btn-primary" type="button">
                        Sign Up
                    </button>
                </div>
            </div>
        </nav>
    );
};
