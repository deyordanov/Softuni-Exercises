import { useNavigate } from "react-router-dom";
import { useRef } from "react";
import { useForm } from "../hooks/useForm";

export default function Add() {
    const { formValues, onChangeHandler, onSubmitHandler } = useForm({
        task: "",
        isCompleted: false,
    });

    const navigator = useNavigate();
    const formRef = useRef(null);

    const onExitClickHandler = (e) => {
        e.preventDefault();
        navigator("/");
    };

    const onOutsideOfFormClickHandler = (e) => {
        //if(the formRef !== undefined && null AND the formRef(our <form>) doesn`t contain the element we have clicked on(meaning if we click on a child of <form> it will be false and if we click on a parent of <form> it will be true))
        if (formRef.current && !formRef.current.contains(e.target)) {
            navigator("/");
        }
    };

    return (
        <div
            onClick={onOutsideOfFormClickHandler}
            className="flex h-screen items-center justify-center"
        >
            <form
                ref={formRef}
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
                        value={formValues.task}
                        onChange={onChangeHandler}
                    />
                </div>

                {/* TODO: Add Error Validation */}
                {/* <p className="text-xs text-red-600">
                    Task must be at least 3 characters long!
                </p> */}

                <div className="flex w-60 items-center">
                    <label htmlFor="isCompleted" className="w-32">
                        Completed:
                    </label>
                    <input
                        type="checkbox"
                        name="isCompleted"
                        id="isCompleted"
                        className="rounded-lg ml-2"
                        checked={formValues.isCompleted}
                        onChange={onChangeHandler}
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
