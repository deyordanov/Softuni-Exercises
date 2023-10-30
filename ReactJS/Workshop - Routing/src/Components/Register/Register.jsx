import { useForm } from "react-hook-form";
import { useContext } from "react";
import { Link } from "react-router-dom";

import { AuthContext } from "../../Contexts/AuthContext";
import {
    LoginOrRegisterFormKeys,
    defaultRegisterFormValues,
} from "../../utilities/constans";
import ErrorMessage from "../../utilities/ErrorMessage";

export default function Register() {
    const { onRegisterSubmit } = useContext(AuthContext);

    const {
        register,
        handleSubmit,
        watch,
        formState: { errors },
    } = useForm({ defaultValues: defaultRegisterFormValues, mode: "onChange" });

    return (
        <section
            id="register-page"
            className="content auth bg-slate-800 flex items-center p-0 relative w-[600px]"
        >
            <form id="register" onSubmit={handleSubmit(onRegisterSubmit)}>
                <div className="container flex flex-col items-center w-[500px] pb-5">
                    <h1 className="font-mono">Register</h1>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="email" className="font-mono">
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
                            name="email"
                            placeholder="megumi@gmail.com"
                        />
                        <ErrorMessage
                            errors={errors}
                            fieldKey={LoginOrRegisterFormKeys.EMAIL}
                        />
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="pass" className="font-mono">
                            Password:
                        </label>
                        <input
                            {...register(LoginOrRegisterFormKeys.PASSWORD, {
                                required: "This field is required!",
                            })}
                            type="password"
                            name="password"
                            id="register-password"
                        />
                        <ErrorMessage
                            errors={errors}
                            fieldKey={LoginOrRegisterFormKeys.PASSWORD}
                        />
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="con-pass" className="font-mono">
                            Confirm Password:
                        </label>
                        <input
                            {...register(
                                LoginOrRegisterFormKeys.PASSWORD_CONFIRMATION,
                                {
                                    required: "This field is required!",
                                    validate: (value) =>
                                        value ===
                                            watch(
                                                LoginOrRegisterFormKeys.PASSWORD
                                            ) || "Passwords do not match!",
                                    pattern: {
                                        value: /^(?=.*[A-Z])(?=.*\d)(?=.*[a-z])(?=.*[!@#$%^&*]).+$/,
                                        message:
                                            "Password must contain at least one uppercase letter, one number, one lowercase letter, and one of the following symbols: !, @, #, $, %, ^, &, *.",
                                    },
                                }
                            )}
                            type="password"
                            name="password_confirmation"
                            id="confirm-password"
                        />
                        <ErrorMessage
                            errors={errors}
                            fieldKey={
                                LoginOrRegisterFormKeys.PASSWORD_CONFIRMATION
                            }
                        />
                    </div>

                    <input
                        className="btn submit bg-slate-700 w-[40%] hover:shadow-lg hover:shadow-white"
                        type="submit"
                        value="Register"
                    />

                    <p className="field">
                        <span className="text-sm absolute bottom-2 right-2 w-auto text-white">
                            If you already have profile click{" "}
                            <Link
                                to={"/login"}
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
