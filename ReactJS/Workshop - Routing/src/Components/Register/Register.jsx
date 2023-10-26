import { useForm } from "react-hook-form";
import { useContext } from "react";

import { AuthContext } from "../../Contexts/AuthContext";
import { LoginFormKeys } from "../../utilities/constans";

export default function Register() {
    const { onRegisterSubmit } = useContext(AuthContext);

    const {
        register,
        handleSubmit,
        watch,
        formState: { errors },
    } = useForm({
        [LoginFormKeys.EMAIL]: "",
        [LoginFormKeys.PASSWORD]: "",
        [LoginFormKeys.PASSWORD_CONFIRMATION]: "",
        mode: "onChange",
    });

    console.log(errors);

    return (
        <section
            id="register-page"
            className="content auth bg-slate-800 flex items-center p-0 relative w-[600px]"
        >
            <form id="register" onSubmit={handleSubmit(onRegisterSubmit)}>
                <div className="container flex flex-col items-center w-[500px]">
                    <h1 className="font-mono">Register</h1>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="email" className="font-mono">
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
                            name="email"
                            placeholder="megumi@gmail.com"
                        />
                        {errors[LoginFormKeys.EMAIL] && (
                            <p className="mt-2 text-xl text-red-500 text-center">
                                {`⚠ ${errors[LoginFormKeys.EMAIL].message}`}
                            </p>
                        )}
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="pass" className="font-mono">
                            Password:
                        </label>
                        <input
                            {...register(LoginFormKeys.PASSWORD, {
                                required: "This field is required!",
                            })}
                            type="password"
                            name="password"
                            id="register-password"
                        />
                        {errors[LoginFormKeys.PASSWORD] && (
                            <p className="mt-2 text-xl text-red-500 text-center">
                                {`⚠ ${errors[LoginFormKeys.PASSWORD].message}`}
                            </p>
                        )}
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="con-pass" className="font-mono">
                            Confirm Password:
                        </label>
                        <input
                            {...register(LoginFormKeys.PASSWORD_CONFIRMATION, {
                                required: "This field is required!",
                                validate: (value) =>
                                    value === watch(LoginFormKeys.PASSWORD) ||
                                    "Passwords do not match!",
                                pattern: {
                                    value: /^(?=.*[A-Z])(?=.*\d)(?=.*[a-z])(?=.*[!@#$%^&*]).+$/,
                                    message:
                                        "Password must contain at least one uppercase letter, one number, one lowercase letter, and one of the following symbols: !, @, #, $, %, ^, &, *.",
                                },
                            })}
                            type="password"
                            name="password_confirmation"
                            id="confirm-password"
                        />
                        {errors[LoginFormKeys.PASSWORD_CONFIRMATION] && (
                            <p className="mt-2 text-xl text-red-500 text-center">
                                {`⚠ ${
                                    errors[LoginFormKeys.PASSWORD_CONFIRMATION]
                                        .message
                                }`}
                            </p>
                        )}
                    </div>

                    <input
                        className="btn submit bg-slate-700 w-[40%] hover:shadow-lg hover:shadow-white"
                        type="submit"
                        value="Register"
                    />

                    <p className="field">
                        <span className="text-sm absolute bottom-2 right-2 w-auto text-white">
                            If you already have profile click{" "}
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
