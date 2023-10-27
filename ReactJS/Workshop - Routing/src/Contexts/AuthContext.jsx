import { createContext, useContext } from "react";
import { useNavigate } from "react-router-dom";
import PropTypes from "prop-types";

import * as authService from "../Services/authService";
import useLocalStorage from "../hooks/useLocalStorage";

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [auth, setAuth] = useLocalStorage("auth", {});
    const navigate = useNavigate();

    const onLoginSubmit = async (data) => {
        try {
            const response = await authService.login(data);

            setAuth(response);

            navigate("/catalogue");
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
        authService.logout(auth.accessToken);
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

export const useAuthContext = () => {
    const context = useContext(AuthContext);

    return context;
};

AuthProvider.propTypes = {
    children: PropTypes.object,
};
