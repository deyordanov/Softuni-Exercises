import * as request from "./requester";

const baseUrl = "http://localhost:3030/jsonstore/games";

export const getAll = async () => {
    const data = await request.get(baseUrl);
    const games = Object.values(data);

    return games;
};
