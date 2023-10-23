import * as requester from "./requester";

const baseUrl = "http://localhost:3030/jsonstore/games";

export const getAll = async () => {
    const response = await requester.get(baseUrl);
    const games = Object.values(response);

    return games;
};

export const getOne = async (gameId) => {
    const response = await requester.get(`${baseUrl}/${gameId}`);

    return response;
};

export const create = async (data) => {
    data = {
        title: data.title,
        imageUrl: data.imageUrl,
        maxLevel: Number(data.maxLevel),
        genres: data.category,
        description: data.summary,
    };

    const response = await requester.post(JSON.stringify(data), baseUrl);

    return response;
};
