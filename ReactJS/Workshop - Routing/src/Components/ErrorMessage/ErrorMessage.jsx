import PropTypes from "prop-types";

export default function ErrorMessage({ errors, fieldKey }) {
    if (errors[fieldKey]) {
        return (
            <p className="mt-2 text-xl text-red-500">
                {`⚠ ${errors[fieldKey].message}`}
            </p>
        );
    }

    return null;
}

ErrorMessage.propTypes = {
    errors: PropTypes.object,
    fieldKey: PropTypes.string,
};
