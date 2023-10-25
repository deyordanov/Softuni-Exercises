import { useContext } from "react";

import { LoginFormKeys } from "../../utilities/constans";
import { useForm } from "../../hooks/useForm";
import { AuthContext } from "../../Contexts/AuthContext";

export default function Login() {
    const { onLoginSubmit } = useContext(AuthContext);
    const { values, onChangeHandler, onSubmit } = useForm(onLoginSubmit, {
        [LoginFormKeys.EMAIL]: "",
        [LoginFormKeys.PASSWORD]: "",
    });

    return (
        <section
            id="login-page"
            className="auth bg-slate-800 flex items-center p-0 relative"
        >
            <form id="login" onSubmit={onSubmit}>
                <div className="container flex flex-col items-center">
                    <h1 className="font-mono">Login</h1>
                    <div>
                        <label
                            htmlFor={LoginFormKeys.EMAIL}
                            className="font-mono"
                        >
                            Email:
                        </label>
                        <input
                            value={values[LoginFormKeys.EMAIL]}
                            onChange={onChangeHandler}
                            type="email"
                            id="email"
                            name={LoginFormKeys.EMAIL}
                            placeholder="nanami@gmail.com"
                        />
                    </div>

                    <div>
                        <label
                            htmlFor={LoginFormKeys.PASSWORD}
                            className="font-mono"
                        >
                            Password:
                        </label>
                        <input
                            value={values[LoginFormKeys.PASSWORD]}
                            onChange={onChangeHandler}
                            type="password"
                            id="login-password"
                            name={LoginFormKeys.PASSWORD}
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
