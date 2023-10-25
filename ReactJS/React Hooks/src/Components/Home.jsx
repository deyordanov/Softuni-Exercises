import { useState, useEffect } from "react";

import * as todoService from "../services/todoService";
import Header from "./Header";
import TodoList from "./TodoList";
import { Button } from "react-bootstrap";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";

export default function Home() {
    const [todos, setTodos] = useState([]);

    useEffect(() => {
        todoService
            .getAll()
            .then((response) => setTodos(response))
            .catch((error) => console.log(error));
    }, [todos]);

    const onTodoUpdate = async (data) => {
        const updatedTodo = await todoService.updateTodo(data);

        setTodos((prevTodos) =>
            prevTodos.map((todo) =>
                todo._id === updatedTodo._id ? updatedTodo : todo
            )
        );
    };

    const onTodoDelete = async (todoId) => {
        await todoService.remove(todoId);

        setTodos((prevTodos) => prevTodos.map((todo) => todo._id !== todoId));
    };

    return (
        <div className="flex flex-column items-center gap-3">
            <Header />

            <TodoList
                todos={todos}
                onTodoUpdate={onTodoUpdate}
                onTodoDelete={onTodoDelete}
            />

            <Button
                variation="primary"
                size="lg"
                className="w-[10%] bg-blue-500 text-lg text-center p-0"
            >
                <Link to="/add">Add</Link>
            </Button>
        </div>
    );
}

Home.propTypes = {
    todos: PropTypes.array,
    onTodoUpdate: PropTypes.func,
};
