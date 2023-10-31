const baseUrl = "http://localhost:3030/jsonstore";

export function getPosts() {
  return fetch(`${baseUrl}/posts`).then((response) => response.json());
}

export function getUsers() {
  return fetch(`${baseUrl}/users`).then((response) => response.json());
}

export function getUser(id) {
  return fetch(`${baseUrl}/users/${id}`).then((response) => response.json());
}
