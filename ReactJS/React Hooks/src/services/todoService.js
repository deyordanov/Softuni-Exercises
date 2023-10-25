import * as requester from "./requestser";

const baseUrl = "http://localhost:3030/jsonstore/todos";

export const getAll = async () => {
    const data = await requester.get(baseUrl);

    return Object.values(data);
};

export const updateTodo = async (data) => {
    const response = await requester.put(
        JSON.stringify(data),
        `${baseUrl}/${data._id}`
    );

    return response;
};

export const create = async (data) => {
    await requester.post(JSON.stringify(data), baseUrl);
};

export const remove = async (todoId) => {
    await requester.remove(`${baseUrl}/${todoId}`);
};
