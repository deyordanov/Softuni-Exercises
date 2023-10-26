import * as requester from "./requester";

const baseUrl = "http://localhost:3030/jsonstore/comments";

export const getAll = async () => {
    const response = await requester.get(baseUrl);

    return response;
};

export const create = async (data) => {
    const response = await requester.post(JSON.stringify(data), baseUrl);

    return response;
};

export const getGameComments = async (gameId) => {
    const comments = await getAll();

    // const query = encodeURIComponent(`gameId="${gameId}"`);
    // const gameComments = await requester.get(`${baseUrl}?where=${query}`);

    const gameComments = Object.values(comments).filter(
        (x) => x.gameId === gameId
    );

    return gameComments;
};
