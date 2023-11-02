import { createContext } from "react";
import { useNavigate } from "react-router-dom";
import PropTypes from "prop-types";

import * as authService from "../Services/authService";
import useLocalStorage from "../hooks/useLocalStorage";

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [auth, setAuth] = useLocalStorage("auth", {});
    const navigate = useNavigate();

    const onLoginSubmit = async (data, location) => {
        try {
            //Returning to the last page we were at before logging in
            //Making sure the location pathname is not '/logout' since it would load the onLogout function again, but this time without a token and an error occurs
            const from =
                location.pathname == null || location.pathname === "/logout"
                    ? "/"
                    : location.pathname;
            // location && location.pathname && location.pathname !== "/logout"
            //     ? { pathname: location.pathname }
            //     : { pathname: "/" };

            const response = await authService.login(data);

            setAuth(response);

            navigate(from);
        } catch (error) {
            console.log("Invalid email or password!");
        }
    };

    const onRegisterSubmit = async (data) => {
        try {
            const response = await authService.register(data);

            setAuth(response);

            navigate("/catalogue");
        } catch (error) {
            console.log("Couldn`t register!");
        }
    };

    const onLogout = async () => {
        authService.logout();
        setAuth({});
    };

    const authContextData = {
        onLoginSubmit,
        onRegisterSubmit,
        onLogout,
        userId: auth._id,
        userEmail: auth.email,
        token: auth.accessToken,
        isAuthenticated: !!auth.accessToken,
    };

    return (
        <AuthContext.Provider value={authContextData}>
            {children}
        </AuthContext.Provider>
    );
};

AuthProvider.propTypes = {
    children: PropTypes.object,
};
