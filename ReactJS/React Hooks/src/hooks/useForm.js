import { useState } from "react";
import * as todoService from "../services/todoService";
import { useNavigate } from "react-router-dom";

//Trying to make this as generic as possible
export const useForm = (initialFormValues) => {
    const [formValues, setFormValues] = useState(initialFormValues);
    const navigator = useNavigate();

    const onChangeHandler = (e) => {
        setFormValues((state) => ({
            ...state,
            [e.target.name]:
                e.target.name === "isCompleted"
                    ? !state.isCompleted
                    : e.target.value,
        }));
    };

    const onSubmitHandler = (e) => {
        e.preventDefault();
        todoService
            .create(formValues)
            .then(navigator("/"))
            .catch((error) => console.log(error));
    };

    return { formValues, onChangeHandler, onSubmitHandler };
};
