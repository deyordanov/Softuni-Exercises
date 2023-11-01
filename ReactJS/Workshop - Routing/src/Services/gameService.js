import * as requester from "./requester";

const baseUrl = "http://localhost:3030/data/games";

const getAuthHeaders = () => {
    const token = JSON.parse(localStorage.getItem("auth")).accessToken;
    return {
        "Content-Type": "application/json",
        "X-Authorization": token,
    };
};

export const getAll = async () => {
    await new Promise((resolve) => setTimeout(resolve, 3000));
    const response = await requester.get(baseUrl);
    const games = Object.values(response);
    return games;
};

export const getOne = async (gameId) => {
    const response = await requester.get(`${baseUrl}/${gameId}`);
    return response;
};

export const create = async (data) => {
    const headers = getAuthHeaders();
    const response = await requester.authorizationPost(
        headers,
        JSON.stringify(data),
        baseUrl
    );
    return response;
};

export const remove = async (gameId) => {
    const headers = getAuthHeaders();
    await requester.authorizationDelete(headers, {}, `${baseUrl}/${gameId}`);
    return gameId;
};

export const edit = async (data) => {
    const headers = getAuthHeaders();
    const response = await requester.put(
        headers,
        JSON.stringify(data),
        `${baseUrl}/${data._id}`
    );
    return response;
};
