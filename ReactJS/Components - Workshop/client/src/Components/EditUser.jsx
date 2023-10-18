import { useState } from "react";
import PropTypes from "prop-types";

import EditComponent from "./EditComponent";
import * as userService from "../Services/userService";

export default function EditUser({
    _id,
    firstName,
    lastName,
    email,
    imageUrl,
    phoneNumber,
    address,
    add,
    onExitClick,
}) {
    //Error handling -> submit
    const [canSubmit, setCanSubmit] = useState(true);
    const [formData, setFormData] = useState({
        firstName,
        lastName,
        email,
        imageUrl,
        phoneNumber,
        country: address.country,
        city: address.city,
        street: address.street,
        streetNumber: address.streetNumber,
    });

    //    country: string,
    // city: string;
    // street: string;
    // streetNumber: number;

    const handleSubmit = async (e) => {
        e.preventDefault();
        //Not the best way to seperate the post / put requests
        if (add) {
            console.log("ADDING");
            userService.createOne({
                address: {
                    country: formData.country,
                    city: formData.city,
                    street: formData.street,
                    streetNumber: formData.streetNumber,
                },
                firstName: formData.firstName,
                lastName: formData.lastName,
                email: formData.email,
                imageUrl: formData.imageUrl,
                phoneNumber: formData.phoneNumber,
            });
            onExitClick();
        } else if (canSubmit) {
            userService.updateOne(_id, formData);
            onExitClick();
        }
    };

    return (
        <>
            <div className="overlay">
                <div className="backdrop"></div>
                <div className="modal">
                    <div className="user-container">
                        <header className="headers">
                            <h2>Edit User/Add User</h2>
                            <button
                                onClick={() => onExitClick()}
                                className="btn close"
                            >
                                <svg
                                    aria-hidden="true"
                                    focusable="false"
                                    data-prefix="fas"
                                    data-icon="xmark"
                                    className="svg-inline--fa fa-xmark"
                                    role="img"
                                    xmlns="http://www.w3.org/2000/svg"
                                    viewBox="0 0 320 512"
                                >
                                    <path
                                        fill="currentColor"
                                        d="M310.6 361.4c12.5 12.5 12.5 32.75 0 45.25C304.4 412.9 296.2 416 288 416s-16.38-3.125-22.62-9.375L160 301.3L54.63 406.6C48.38 412.9 40.19 416 32 416S15.63 412.9 9.375 406.6c-12.5-12.5-12.5-32.75 0-45.25l105.4-105.4L9.375 150.6c-12.5-12.5-12.5-32.75 0-45.25s32.75-12.5 45.25 0L160 210.8l105.4-105.4c12.5-12.5 32.75-12.5 45.25 0s12.5 32.75 0 45.25l-105.4 105.4L310.6 361.4z"
                                    ></path>
                                </svg>
                            </button>
                        </header>
                        <form onSubmit={(e) => handleSubmit(e)}>
                            <div className="form-row">
                                <div className="form-group">
                                    <EditComponent
                                        value={firstName}
                                        label={"First Name"}
                                        type={"firstName"}
                                        setCanSubmit={setCanSubmit}
                                        setFormData={setFormData}
                                        formData={formData}
                                    />
                                </div>

                                <div className="form-group">
                                    <EditComponent
                                        value={lastName}
                                        label={"Last Name"}
                                        type={"lastName"}
                                        setFormData={setFormData}
                                        setCanSubmit={setCanSubmit}
                                        formData={formData}
                                    />
                                </div>
                            </div>

                            <div className="form-row">
                                <div className="form-group">
                                    <EditComponent
                                        value={email}
                                        label={"Email"}
                                        type={"email"}
                                        setFormData={setFormData}
                                        setCanSubmit={setCanSubmit}
                                        formData={formData}
                                    />
                                </div>
                                <div className="form-group">
                                    <EditComponent
                                        value={phoneNumber}
                                        label={"Phone number"}
                                        type={"phoneNumber"}
                                        setFormData={setFormData}
                                        setCanSubmit={setCanSubmit}
                                        formData={formData}
                                    />
                                </div>
                            </div>

                            <div className="form-group long-line">
                                <EditComponent
                                    value={imageUrl}
                                    label={"Image Url"}
                                    type={"imageUrl"}
                                    setFormData={setFormData}
                                    setCanSubmit={setCanSubmit}
                                    formData={formData}
                                />
                            </div>

                            <div className="form-row">
                                <div className="form-group">
                                    <EditComponent
                                        value={address.country}
                                        label={"Country"}
                                        type={"country"}
                                        setFormData={setFormData}
                                        setCanSubmit={setCanSubmit}
                                        formData={formData}
                                    />
                                </div>
                                <div className="form-group">
                                    <EditComponent
                                        value={address.city}
                                        label={"City"}
                                        type={"city"}
                                        setFormData={setFormData}
                                        setCanSubmit={setCanSubmit}
                                        formData={formData}
                                    />
                                </div>
                            </div>

                            <div className="form-row">
                                <div className="form-group">
                                    <EditComponent
                                        value={address.street}
                                        label={"Street"}
                                        type={"street"}
                                        setFormData={setFormData}
                                        setCanSubmit={setCanSubmit}
                                        formData={formData}
                                    />
                                </div>
                                <div className="form-group">
                                    <EditComponent
                                        value={address.streetNumber}
                                        label={"Street number"}
                                        type={"streetNumber"}
                                        setFormData={setFormData}
                                        setCanSubmit={setCanSubmit}
                                        formData={formData}
                                    />
                                </div>
                            </div>
                            <div id="form-actions">
                                <button
                                    id="action-save"
                                    className="btn"
                                    type="submit"
                                >
                                    Save
                                </button>
                                <button
                                    onClick={() => onExitClick()}
                                    id="action-cancel"
                                    className="btn"
                                    type="button"
                                >
                                    Cancel
                                </button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </>
    );
}

EditUser.propTypes = {
    _id: PropTypes.string,
    firstName: PropTypes.string,
    lastName: PropTypes.string,
    email: PropTypes.string,
    imageUrl: PropTypes.string,
    phoneNumber: PropTypes.string,
    address: PropTypes.object,
    onExitClick: PropTypes.func,
    add: PropTypes.bool,
};
