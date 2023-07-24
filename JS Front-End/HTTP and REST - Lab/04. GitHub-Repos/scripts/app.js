function loadRepos() {
  const BASE_URL = "https://api.github.com/users/testnakov/repos";
  fetch(BASE_URL)
    .then((res) => res.text())
    .then((data) => (document.querySelector("#res").textContent = data))
    .catch((err) => console.error(err));
}
