export const request = async (method, headers, body, url) => {
    let options = {
        method,
        headers,
    };

    if (method !== "GET" && method !== "HEAD") {
        options = { ...options, body };
    }

    const response = await fetch(url, options);

    if (!response.ok) {
        throw response;
    }

    try {
        return await response.json();
    } catch (error) {
        return {};
    }
};

export const get = request.bind(null, "GET", {}, {});

export const post = request.bind(null, "POST", {
    "Content-Type": "application/json",
});

export const put = request.bind(null, "PUT");

export const authorizationDelete = request.bind(null, "DELETE");

export const authorizationPost = request.bind(null, "POST");

export const authorizationGet = request.bind(null, "GET");

//..........
