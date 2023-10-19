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
        body: JSON.stringify({
            address: {
                country: formData.country,
                city: formData.city,
                street: formData.street,
                streetNumber: formData.streetNumber,
            },
            firstName: formData.firstName,
            lastName: formData.lastName,
            email: formData.email,
            imageUrl: formData.imageUrl,
            phoneNumber: formData.phoneNumber,
        }),
    });
};

export const createOne = async (formData) => {
    await fetch(baseUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            address: {
                country: formData.country,
                city: formData.city,
                street: formData.street,
                streetNumber: formData.streetNumber,
            },
            firstName: formData.firstName,
            lastName: formData.lastName,
            email: formData.email,
            imageUrl: formData.imageUrl,
            phoneNumber: formData.phoneNumber,
        }),
    });
};

export const deleteOne = async (userId) => {
    await fetch(`${baseUrl}/${userId}`, { method: "DELETE" });
};
