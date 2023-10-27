import * as requester from "./requester";

const baseUrl = "http://localhost:3030/data/comments";

const getAuthHeaders = () => {
    const token = JSON.parse(localStorage.getItem("auth")).accessToken;
    return {
        "Content-Type": "application/json",
        "X-Authorization": token,
    };
};

export const getAll = async () => {
    const response = await requester.get(baseUrl);

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

export const getGameComments = async (gameId) => {
    const query = encodeURIComponent(`gameId="${gameId}"`);
    const gameComments = await requester.get(`${baseUrl}?where=${query}`);

    return gameComments;
};
