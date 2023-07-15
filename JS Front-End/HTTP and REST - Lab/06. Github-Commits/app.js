async function loadCommits() {
  const BASE_URL = "https://api.github.com/repos/";
  const username = document.querySelector("#username");
  const repo = document.querySelector("#repo");
  const commits = document.querySelector("#commits");
  try {
    const allCommitsStream = await fetch(
      `${BASE_URL}${username.value}/${repo.value}/commits`
    );
    const allCommits = await allCommitsStream.json();
    allCommits.forEach(({ commit }) => {
      const li = document.createElement("li");
      li.textContent = `${commit.author.name}: ${commit.message}`;
      commits.appendChild(li);
    });
  } catch (error) {
    const li = document.createElement("li");
    li.textContent = `Error: ${error.status} (Not Found)`;
    commits.appendChild(li);
  }
}
