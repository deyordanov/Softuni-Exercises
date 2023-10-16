import classNames from "classnames";
import PropTypes from "prop-types";

export default function Todo({ _id, text, isCompleted, toggleTodoStatus }) {
    //Using the 'classnames' package
    const trClasses = classNames("todo", {
        "is-completed": isCompleted,
    });

    return (
        <tr className={trClasses}>
            <td>{text}</td>
            <td>{isCompleted ? "Complete" : "Incomplete"}</td>
            <td className="todo-action">
                <button
                    onClick={() => toggleTodoStatus(_id)}
                    className="btn todo-btn"
                >
                    Change status
                </button>
            </td>
        </tr>
    );
}

Todo.propTypes = {
    isCompleted: PropTypes.bool,
    text: PropTypes.string,
    _id: PropTypes.string,
    toggleTodoStatus: PropTypes.func,
};
