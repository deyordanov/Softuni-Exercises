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
    //Due to server limitations in order to implement the like counter have to add the owner token to the comment itself
    data = {
        ...data,
        ownerToken: JSON.parse(localStorage.getItem("auth")).accessToken,
    };
    const headers = getAuthHeaders();

    const response = await requester.authorizationPost(
        headers,
        JSON.stringify(data),
        baseUrl
    );

    return response;
};

export const like = async (data, action, userId) => {
    //Due to server limitations in order to implement the like counter I have to take the 'ownerToken' from the comment and manually add it to the headers
    const headers = {
        "Content-Type": "application/json",
        "X-Authorization": data.ownerToken,
    };
    // add -> add like, remove -> remove like
    switch (action) {
        case "add":
            data = { ...data, likes: data.likes + 1 };
            data.likedBy.push(userId);
            break;
        case "remove":
            data = { ...data, likes: data.likes - 1 };
            data.likedBy = data.likedBy.filter((x) => x !== userId);
            break;
    }

    const response = await requester.put(
        headers,
        JSON.stringify(data),
        `${baseUrl}/${data._id}`
    );
    console.log(response);
    return response;
};

export const getGameComments = async (gameId) => {
    const query = encodeURIComponent(`gameId="${gameId}"`);
    const gameComments = await requester.get(`${baseUrl}?where=${query}`);

    return gameComments;
};
