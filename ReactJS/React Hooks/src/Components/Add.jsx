import { useState } from "react";
import * as todoService from "../services/todoService";
import { useNavigate } from "react-router-dom";

export default function Add() {
    const [task, setTask] = useState(" ");
    const [isCompleted, setIsCompleted] = useState(false);
    const navigator = useNavigate();

    const onTaskChangeHandler = (e) => {
        setTask(e.target.value);
    };

    const onIsCompletedChangeHandler = () => {
        setIsCompleted(!isCompleted);
    };

    const onSubmitHandler = (e) => {
        e.preventDefault();
        todoService
            .create({ task, isCompleted })
            .then(navigator("/"))
            .catch((error) => console.log(error));
    };

    const onExitClickHandler = (e) => {
        e.preventDefault();
        navigator("/");
    };

    return (
        <div className="flex h-screen items-center justify-center">
            <form
                onSubmit={onSubmitHandler}
                className="flex flex-column items-center gap-2 mt-10 bg-slate-200 w-[50%] p-3 border-black border-solid border-2 rounded-xl relative shadow-xl shadow-rose-500"
            >
                <button
                    onClick={onExitClickHandler}
                    className="absolute top-0 right-3 hover:text-rose-800"
                >
                    x
                </button>
                <div className="flex w-60 items-center mt-2">
                    <label htmlFor="task" className="w-32">
                        Task:
                    </label>
                    <input
                        type="text"
                        name="task"
                        id="task"
                        className="rounded-lg ml-2 w-26"
                        value={task}
                        onChange={onTaskChangeHandler}
                    />
                </div>

                <div className="flex w-60 items-center">
                    <label htmlFor="isCompleted" className="w-32">
                        Completed:
                    </label>
                    <input
                        type="checkbox"
                        name="isCompleted"
                        id="isCompleted"
                        className="rounded-lg ml-2"
                        checked={isCompleted}
                        onChange={onIsCompletedChangeHandler}
                    />
                </div>

                <input
                    type="submit"
                    className="bg-blue-500 rounded-lg p-0.5 ml-1 w-[30%] text-white"
                />
            </form>
        </div>
    );
}
