import PropTypes from "prop-types";

export default function AddButton({ onTodoAdd }) {
    return (
        <div className="add-btn-container">
            <button className="btn" onClick={() => onTodoAdd()}>
                + Add new Todo
            </button>
        </div>
    );
}

AddButton.propTypes = {
    onTodoAdd: PropTypes.func,
};
