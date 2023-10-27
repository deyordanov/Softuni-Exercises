import * as requester from "./requester.js";

const baseUrl = "http://localhost:3030/users";

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

export const logout = (token) => {
    const headers = {
        "Content-Type": "application/json",
        "X-Authorization": token,
    };

    requester.authorizationGet(headers, {}, `${baseUrl}/logout`);
};
