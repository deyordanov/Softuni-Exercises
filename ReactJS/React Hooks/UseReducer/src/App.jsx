import "./App.css";
import { useState, useReducer } from "react";

import Todo from "./Components/Todo";

const ACTIONS = {
  ADD_TODO: "add-todo",
  TOGGLE_TODO: "toggle-todo",
  DELETE_TODO: "delete-todo",
};

function reducer(todos, action) {
  switch (action.type) {
    case ACTIONS.ADD_TODO:
      return [...todos, newTodo(action.payload.name)];
    case ACTIONS.TOGGLE_TODO:
      return todos.map((todo) =>
        todo.id === action.payload.id
          ? { ...todo, complete: !todo.complete }
          : todo
      );
    case ACTIONS.DELETE_TODO:
      return todos.filter((todo) => todo.id !== action.payload.id);
  }
}

function newTodo(name) {
  return { id: Date.now(), name, complete: false };
}

function App() {
  const [todos, dispatch] = useReducer(reducer, []);
  const [name, setName] = useState("");

  function handleSubmit(e) {
    e.preventDefault();
    dispatch({ type: ACTIONS.ADD_TODO, payload: { name } });
    setName("");
  }

  function handleToggle(id) {
    dispatch({ type: ACTIONS.TOGGLE_TODO, payload: { id } });
  }

  function handleDelete(id) {
    dispatch({ type: ACTIONS.DELETE_TODO, payload: { id } });
  }

  console.log(todos);

  return (
    <>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
      </form>
      {todos.map((todo) => (
        <Todo
          key={todo.id}
          {...todo}
          handleToggle={handleToggle}
          handleDelete={handleDelete}
        />
      ))}
    </>
  );
}

export default App;
