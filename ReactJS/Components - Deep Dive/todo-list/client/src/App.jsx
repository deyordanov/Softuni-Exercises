import "./App.css";
import { useState, useEffect } from "react";

import AddButton from "./Components/AddButton";
import Footer from "./Components/Footer";
import Header from "./Components/Header";
import Loading from "./Components/Loading";
import Table from "./Components/Table";

function App() {
    const [todos, setTodos] = useState([]);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        fetch("http://localhost:3030/jsonstore/todos")
            .then((response) => response.json())
            .then((data) => {
                setTodos(Object.values(data));
                setIsLoading(false);
            });
    }, []);

    const toggleTodoStatus = (id) => {
        setTodos((state) =>
            state.map((x) =>
                x._id === id ? { ...x, isCompleted: !x.isCompleted } : x
            )
        );
    };

    const onTodoAdd = () => {
        const _id =
            "todo_" +
            (Number(todos[todos.length - 1]._id.split("todo_")[1]) + 1);
        const text = prompt("Task:");
        const newTodo = { _id, text, isCompleted: false };
        setTodos((state) => [newTodo, ...state]);
    };

    return (
        <>
            <Header />

            <main className="main">
                <section className="todo-list-container">
                    <h1>Todo List</h1>

                    <AddButton onTodoAdd={onTodoAdd} />

                    <div className="table-wrapper">
                        {/* <Loading /> */}

                        {isLoading ? (
                            <Loading />
                        ) : (
                            <Table
                                todos={todos}
                                toggleTodoStatus={toggleTodoStatus}
                            />
                        )}
                        {/* 
                        <Table
                            todos={todos}
                            toggleTodoStatus={toggleTodoStatus}
                        /> */}
                    </div>
                </section>
            </main>

            <Footer />
        </>
    );
}

export default App;
