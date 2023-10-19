import { useState, useEffect, useCallback } from "react";
import PropTypes from "prop-types";

import inputValidator from "../Utils/inputValidator";
import { ERROR_MESSAGES } from "../Utils/errorMessages";
import { ICON_CLASSES } from "../Utils/iconClasses";

export default function EditComponent({
    value,
    label,
    type,
    setCanSubmit,
    setFormData,
    formData,
}) {
    const [error, setError] = useState(false);

    //Handle validation has to be wrapper in a callback hook
    const handleValidation = useCallback(
        (e) => {
            const isValid = inputValidator(type, e.currentTarget.value);
            setCanSubmit(!isValid);
            setError(isValid);
        },
        [type, setCanSubmit, setError]
    );

    //On load validation
    useEffect(() => {
        handleValidation({ currentTarget: { value: value || "" } });
    }, [handleValidation, label, value]);

    return (
        <>
            <label htmlFor={type}>{label}</label>
            <div className="input-wrapper">
                <span>
                    <i className={ICON_CLASSES[type]}></i>
                </span>
                <input
                    id={type}
                    name={type}
                    type="text"
                    defaultValue={value}
                    onInput={(e) => handleValidation(e)}
                    onChange={(e) =>
                        setFormData({
                            ...formData,
                            [type]: e.currentTarget.value,
                        })
                    }
                />
            </div>
            {error && <p className="form-error">{ERROR_MESSAGES[type]}</p>}
        </>
    );
}

EditComponent.propTypes = {
    value: PropTypes.any,
    label: PropTypes.string,
    type: PropTypes.string,
    setCanSubmit: PropTypes.func,
    setFormData: PropTypes.func,
    formData: PropTypes.object,
};
