import { useContext } from "react";
import { useForm } from "react-hook-form";
import { Link } from "react-router-dom";

import {
    LoginOrRegisterFormKeys,
    defaultLoginUserFormValues,
} from "../../utilities/constans";
import { AuthContext } from "../../Contexts/AuthContext";
import ErrorMessage from "../ErrorMessage/ErrorMessage";

export default function Login() {
    const { onLoginSubmit } = useContext(AuthContext);

    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm({
        defaultValues: defaultLoginUserFormValues,
        mode: "onChange",
    });

    return (
        <section
            id="login-page"
            className="auth bg-slate-800 flex items-center relative w-[600px]"
        >
            <form id="login" onSubmit={handleSubmit(onLoginSubmit)}>
                <div className="container flex flex-col items-center w-[500px] pb-5">
                    <h1 className="font-mono">Login</h1>
                    <div className="w-full flex flex-col items-center">
                        <label
                            htmlFor={LoginOrRegisterFormKeys.EMAIL}
                            className="font-mono"
                        >
                            Email:
                        </label>
                        <input
                            {...register(LoginOrRegisterFormKeys.EMAIL, {
                                required: "This field is required!",
                                minLength: {
                                    value: 10,
                                    message:
                                        "Email must be at least 10 characters long!",
                                },
                            })}
                            type="email"
                            id="email"
                            name={LoginOrRegisterFormKeys.EMAIL}
                            placeholder="nanami@gmail.com"
                        />
                        <ErrorMessage
                            errors={errors}
                            fieldKey={LoginOrRegisterFormKeys.EMAIL}
                        />
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label
                            htmlFor={LoginOrRegisterFormKeys.PASSWORD}
                            className="font-mono"
                        >
                            Password:
                        </label>
                        <input
                            {...register(LoginOrRegisterFormKeys.PASSWORD, {
                                required: "This field is required!",
                            })}
                            type="password"
                            id="login-password"
                            name={LoginOrRegisterFormKeys.PASSWORD}
                        />
                        <ErrorMessage
                            errors={errors}
                            fieldKey={LoginOrRegisterFormKeys.PASSWORD}
                        />
                    </div>

                    <input
                        type="submit"
                        className="btn submit bg-slate-700 w-[40%] hover:shadow-lg hover:shadow-white"
                        value="Login"
                    />
                    <p className="field">
                        <span className="text-sm absolute bottom-2 right-2 w-auto text-white">
                            If you don`t have profile click{" "}
                            <Link
                                to={"/register"}
                                className="text-red-500 underline"
                            >
                                here
                            </Link>
                        </span>
                    </p>
                </div>
            </form>
        </section>
    );
}

//Using HOC
// export default withAuth(Login);
