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

export const create = async (data) => {
    const headers = {
        "Content-Type": "application/json",
        "X-Authorization": data.token,
    };

    //Remapping the object since the properties have different names
    data = {
        title: data.title,
        imageUrl: data.imageUrl,
        maxLevel: Number(data.maxLevel),
        genres: data.category,
        description: data.summary,
    };

    const response = await requester.authorizationPost(
        headers,
        JSON.stringify(data),
        baseUrl
    );

    return response;
};
