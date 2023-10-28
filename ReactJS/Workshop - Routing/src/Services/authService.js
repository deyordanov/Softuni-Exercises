import * as requester from "./requester.js";

const baseUrl = "http://localhost:3030/users";

const getAuthHeaders = () => {
    const token = JSON.parse(localStorage.getItem("auth")).accessToken;
    return {
        "Content-Type": "application/json",
        "X-Authorization": token,
    };
};

export const login = (loginData) =>
    requester.post(JSON.stringify(loginData), `${baseUrl}/login`);

export const register = (registerData) => {
    return requester.post(
        JSON.stringify({
            email: registerData.email,
            password: registerData.password,
        }),
        `${baseUrl}/register`
    );
};

export const logout = () => {
    const headers = getAuthHeaders();

    requester.authorizationGet(headers, {}, `${baseUrl}/logout`);
};
