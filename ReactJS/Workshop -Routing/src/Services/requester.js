export const request = async (method, headers, body, url) => {
    let options = {
        method,
        headers,
    };

    if (method !== "GET" && method !== "HEAD") {
        options = { ...options, body };
    }

    const response = await fetch(url, options);

    try {
        return await response.json();
    } catch (error) {
        return {};
    }
};

export const get = request.bind(
    null,
    "GET",
    { "Content-Type": "json/application" },
    {}
);

export const post = request.bind(null, "POST", {
    "Content-Type": "json/application",
});

//..........
