import ListGroup from "react-bootstrap/ListGroup";
import PropTypes from "prop-types";
import TodoItem from "./TodoItem";

export default function TodoList({ todos }) {
    return (
        <ListGroup className="w-[50%] shadow-xl shadow-rose-500 border-solid border-black border-2">
            {todos.map((x) => (
                <TodoItem key={x._id} {...x} />
            ))}
        </ListGroup>
    );
}

TodoList.propTypes = {
    todos: PropTypes.array,
    onTodoUpdate: PropTypes.func,
    onTodoDelete: PropTypes.func,
};
