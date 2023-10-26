import { useContext } from "react";
import { useForm } from "react-hook-form";

import { LoginFormKeys } from "../../utilities/constans";
import { AuthContext } from "../../Contexts/AuthContext";

export default function Login() {
    const { onLoginSubmit } = useContext(AuthContext);

    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm({
        defaultValues: {
            [LoginFormKeys.EMAIL]: "",
            [LoginFormKeys.PASSWORD]: "",
        },
        mode: "onBlur",
    });

    return (
        <section
            id="login-page"
            className="auth bg-slate-800 flex items-center p-0 relative"
        >
            <form id="login" onSubmit={handleSubmit(onLoginSubmit)}>
                <div className="container flex flex-col items-center">
                    <h1 className="font-mono">Login</h1>
                    <label htmlFor={LoginFormKeys.EMAIL} className="font-mono">
                        Email:
                    </label>
                    <input
                        {...register(LoginFormKeys.EMAIL, {
                            required: "This field is required!",
                            minLength: {
                                value: 10,
                                message:
                                    "Email must be at least 10 characters long!",
                            },
                        })}
                        type="email"
                        id="email"
                        name={LoginFormKeys.EMAIL}
                        placeholder="nanami@gmail.com"
                    />
                    {errors[LoginFormKeys.EMAIL] && (
                        <p className="mt-2 text-xl text-red-500">
                            {`⚠ ${errors[LoginFormKeys.EMAIL].message}`}
                        </p>
                    )}

                    <label
                        htmlFor={LoginFormKeys.PASSWORD}
                        className="font-mono"
                    >
                        Password:
                    </label>
                    <input
                        {...register(LoginFormKeys.PASSWORD, {
                            required: "This field is required!",
                        })}
                        type="password"
                        id="login-password"
                        name={LoginFormKeys.PASSWORD}
                    />
                    {errors[LoginFormKeys.PASSWORD] && (
                        <p className="mt-2 text-xl text-red-500">
                            {`⚠ ${errors[LoginFormKeys.PASSWORD].message}`}
                        </p>
                    )}

                    <input
                        type="submit"
                        className="btn submit bg-slate-700 w-[40%] hover:shadow-lg hover:shadow-white"
                        value="Login"
                    />
                    <p className="field">
                        <span className="text-sm absolute bottom-2 right-2 w-auto text-white">
                            If you don`t have profile click{" "}
                            <a href="#" className="text-red-500 underline">
                                here
                            </a>
                        </span>
                    </p>
                </div>
            </form>
        </section>
    );
}
