import * as requester from "./requester";

//In order to implement the like button / like counter we need to use the 'jsonstore'
//Since the 'data' doesn`t allow us to edit the comments (increment / decrement likes) from a user who hasn`t created the comment
//I will leave the auth headers in case I need them later (used with 'data')
const baseUrl = "http://localhost:3030/jsonstore/comments";

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

export const like = async (data, action, userId) => {
    const headers = getAuthHeaders();
    switch (action) {
        case "add":
            data.likedBy.push(userId);
            break;
        case "remove":
            data.likedBy = data.likedBy.filter((x) => x !== userId);
            break;
    }

    const response = await requester.put(
        headers,
        JSON.stringify(data),
        `${baseUrl}/${data._id}`
    );

    return response;
};

export const getGameComments = async (gameId) => {
    // Can be used with 'data'
    // const query = encodeURIComponent(`gameId="${gameId}"`);
    // const gameComments = await requester.get(`${baseUrl}?where=${query}`);
    let response = await getAll();

    const gameComments = Object.values(response).filter(
        (x) => x.gameId === gameId
    );

    return gameComments;
};
