function loadRepos() {
  const BASE_URL = "https://api.github.com/users/";
  const username = document.querySelector("#username");
  const repos = document.querySelector("#repos");
  fetch(`${BASE_URL}${username.value}/repos`)
    .then((res) => res.json())
    .then((data) => {
      data.forEach((input) => {
        const li = document.createElement("li");
        const anchor = document.createElement("a");
        anchor.href = input.html_url;
        anchor.textContent = input.full_name;
        li.appendChild(anchor);
        repos.appendChild(li);
      });
    });
}
