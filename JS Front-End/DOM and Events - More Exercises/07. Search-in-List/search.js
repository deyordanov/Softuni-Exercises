function search() {
  const searchWord = document.querySelector("#searchText").value;
  const towns = Array.from(document.querySelectorAll("li")).filter((town) =>
    town.innerText.includes(searchWord)
  );
  const result = document.querySelector("#result");
  const field = document.querySelector("#searchText");
  field.addEventListener("click", () => {
    towns.forEach((town) => (town.innerHTML = town.innerText));
    result.textContent = "";
  });

  getResult();

  function getResult() {
    towns.forEach((town) => {
      if (town.innerText.includes(searchWord)) {
        town.innerHTML = `<bold><u>${town.innerText}</bold></u>`;
      }

      result.textContent = `${towns.length} matches found`;
    });
  }
}
