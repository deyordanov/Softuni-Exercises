import PropTypes from "prop-types";
import { useReducer } from "react";

import User from "./User";
import UserDetails from "./UserDetails";
import EditUser from "./EditUser";
import * as userService from "../Services/userService";
import DeleteUser from "./DeleteUser";
import Pagination from "./Pagination";
import ArrowDownSvg from "./ArrowDownSvg";

const VIEWS = {
    INFO: "info",
    EDIT: "edit",
    ADD: "add",
    DELETE: "delete",
    NONE: "none",
};
const ACTIONS = {
    USER_SET_VIEW: "set-view",
};

function reducer(state, action) {
    switch (action.type) {
        case ACTIONS.USER_SET_VIEW:
            return {
                view: action.payload.view,
                user: action.payload.user,
            };
    }
}

export default function UserList({ users, setUsers }) {
    const [selectedUser, dispatch] = useReducer(reducer, {
        view: "none",
        user: null,
    });

    const onInfoClick = async (userId) => {
        const user = await userService.getOne(userId);
        const view = VIEWS.INFO;

        dispatch({ type: ACTIONS.USER_SET_VIEW, payload: { user, view } });
    };

    const onExitClick = () => {
        const view = VIEWS.NONE;
        dispatch({
            type: ACTIONS.USER_SET_VIEW,
            payload: { user: null, view },
        });
    };

    const onUserEdit = async (userId) => {
        const user = await userService.getOne(userId);
        const view = VIEWS.EDIT;

        dispatch({ type: ACTIONS.USER_SET_VIEW, payload: { user, view } });
    };

    const onUserAdd = async () => {
        const user = {
            _id: "",
            firstName: "",
            lastName: "",
            email: "",
            imageUrl: "",
            phoneNumber: "",
            address: {},
            add: true,
        };

        const view = VIEWS.ADD;

        dispatch({ type: ACTIONS.USER_SET_VIEW, payload: { user, view } });
    };

    const onUserDelete = async (userId) => {
        const user = await userService.getOne(userId);
        const view = VIEWS.DELETE;

        dispatch({ type: ACTIONS.USER_SET_VIEW, payload: { user, view } });
    };

    const handleDelete = async () => {
        await userService.deleteOne(selectedUser.user._id);
        onExitClick();
    };

    return (
        <>
            {selectedUser.view === VIEWS.INFO && (
                <UserDetails {...selectedUser.user} onExitClick={onExitClick} />
            )}

            {selectedUser.view === VIEWS.EDIT && (
                <EditUser
                    {...selectedUser.user}
                    onExitClick={onExitClick}
                    setUsers={setUsers}
                />
            )}

            {selectedUser.view === VIEWS.ADD && (
                <EditUser
                    {...selectedUser.user}
                    onExitClick={onExitClick}
                    setUsers={setUsers}
                />
            )}

            {selectedUser.view === VIEWS.DELETE && (
                <DeleteUser
                    handleDelete={handleDelete}
                    onExitClick={onExitClick}
                />
            )}

            <div className="table-wrapper">
                {/* Overlap components
            <div className="loading-shade">
                Loading spinner
                <div className="spinner"></div>
                No users added yet
                <div className="table-overlap">
                    <svg
                        aria-hidden="true"
                        focusable="false"
                        data-prefix="fas"
                        data-icon="triangle-exclamation"
                        className="svg-inline--fa fa-triangle-exclamation Table_icon__+HHgn"
                        role="img"
                        xmlns="http://www.w3.org/2000/svg"
                        viewBox="0 0 512 512"
                    >
                        <path
                            fill="currentColor"
                            d="M506.3 417l-213.3-364c-16.33-28-57.54-28-73.98 0l-213.2 364C-10.59 444.9 9.849 480 42.74 480h426.6C502.1 480 522.6 445 506.3 417zM232 168c0-13.25 10.75-24 24-24S280 154.8 280 168v128c0 13.25-10.75 24-23.1 24S232 309.3 232 296V168zM256 416c-17.36 0-31.44-14.08-31.44-31.44c0-17.36 14.07-31.44 31.44-31.44s31.44 14.08 31.44 31.44C287.4 401.9 273.4 416 256 416z"
                        ></path>
                    </svg>
                    <h2>There is no users yet.</h2>
                </div>
                No content overlap component
                <div className="table-overlap">
                    <svg
                        aria-hidden="true"
                        focusable="false"
                        data-prefix="fas"
                        data-icon="triangle-exclamation"
                        className="svg-inline--fa fa-triangle-exclamation Table_icon__+HHgn"
                        role="img"
                        xmlns="http://www.w3.org/2000/svg"
                        viewBox="0 0 512 512"
                    >
                        <path
                            fill="currentColor"
                            d="M506.3 417l-213.3-364c-16.33-28-57.54-28-73.98 0l-213.2 364C-10.59 444.9 9.849 480 42.74 480h426.6C502.1 480 522.6 445 506.3 417zM232 168c0-13.25 10.75-24 24-24S280 154.8 280 168v128c0 13.25-10.75 24-23.1 24S232 309.3 232 296V168zM256 416c-17.36 0-31.44-14.08-31.44-31.44c0-17.36 14.07-31.44 31.44-31.44s31.44 14.08 31.44 31.44C287.4 401.9 273.4 416 256 416z"
                        ></path>
                    </svg>
                    <h2>Sorry, we couldn`t find what you`re looking for.</h2>
                </div>
                On error overlap component
                <div className="table-overlap">
                    <svg
                        aria-hidden="true"
                        focusable="false"
                        data-prefix="fas"
                        data-icon="triangle-exclamation"
                        className="svg-inline--fa fa-triangle-exclamation Table_icon__+HHgn"
                        role="img"
                        xmlns="http://www.w3.org/2000/svg"
                        viewBox="0 0 512 512"
                    >
                        <path
                            fill="currentColor"
                            d="M506.3 417l-213.3-364c-16.33-28-57.54-28-73.98 0l-213.2 364C-10.59 444.9 9.849 480 42.74 480h426.6C502.1 480 522.6 445 506.3 417zM232 168c0-13.25 10.75-24 24-24S280 154.8 280 168v128c0 13.25-10.75 24-23.1 24S232 309.3 232 296V168zM256 416c-17.36 0-31.44-14.08-31.44-31.44c0-17.36 14.07-31.44 31.44-31.44s31.44 14.08 31.44 31.44C287.4 401.9 273.4 416 256 416z"
                        ></path>
                    </svg>
                    <h2>Failed to fetch</h2>
                </div>
            </div> */}
                <table className="table">
                    <thead>
                        <tr>
                            <th>Image</th>
                            <th>
                                First name
                                <ArrowDownSvg />
                            </th>
                            <th>
                                Last name
                                <ArrowDownSvg />
                            </th>
                            <th>
                                Email
                                <ArrowDownSvg />
                            </th>
                            <th>
                                Phone
                                <ArrowDownSvg />
                            </th>
                            <th>
                                Created
                                <ArrowDownSvg />
                            </th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {users.map((user) => (
                            <User
                                key={user._id}
                                {...user}
                                onInfoClick={onInfoClick}
                                onUserEdit={onUserEdit}
                                onUserDelete={onUserDelete}
                            />
                        ))}
                    </tbody>
                </table>
            </div>
            <button onClick={() => onUserAdd()} className="btn-add btn">
                Add new user
            </button>
            <Pagination />
        </>
    );
}

UserList.propTypes = {
    users: PropTypes.array,
    setUsers: PropTypes.func,
};
