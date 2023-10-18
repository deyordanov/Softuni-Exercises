const baseUrl = "http://localhost:3005/api/users";

export const getAll = async () => {
    const response = await fetch(baseUrl);
    const data = await response.json();

    return data.users;
};

export const getOne = async (userId) => {
    const response = await fetch(`${baseUrl}/${userId}`);
    const data = await response.json();

    return data.user;
};

export const updateOne = async (userId, formData) => {
    await fetch(`${baseUrl}/${userId}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(formData),
    });
};

export const createOne = async (user) => {
    const response = await fetch(baseUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(user),
    });

    const data = await response.json();

    console.log(data);
};
