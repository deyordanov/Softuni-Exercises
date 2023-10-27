import * as requester from "./requester";

const baseUrl = "http://localhost:3030/data/games";

export const getAll = async () => {
    const response = await requester.get(baseUrl);
    const games = Object.values(response);

    return games;
};

export const getOne = async (gameId) => {
    const response = await requester.get(`${baseUrl}/${gameId}`);

    return response;
};

export const create = async (data, token) => {
    const headers = {
        "Content-Type": "application/json",
        "X-Authorization": token,
    };

    const response = await requester.authorizationPost(
        headers,
        JSON.stringify(data),
        baseUrl
    );

    return response;
};

export const remove = async (gameId, token) => {
    const headers = {
        "Content-Type": "application/json",
        "X-Authorization": token,
    };

    await requester.authorizationDelete(headers, {}, `${baseUrl}/${gameId}`);

    return gameId;
};

export const edit = async (data, gameId, token) => {
    const headers = {
        "Content-Type": "application/json",
        "X-Authorization": token,
    };

    const response = await requester.put(
        headers,
        JSON.stringify(data),
        `${baseUrl}/${gameId}`
    );

    return response;
};
