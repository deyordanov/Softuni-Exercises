function solve() {
  document.querySelector("#searchBtn").addEventListener("click", onClick);

  function onClick() {
    const searchField = document.querySelector("#searchField");
    const searchText = searchField.value;
    const boxes = Array.from(document.querySelectorAll("tbody td"));
    boxes.forEach((box) => {
      if (box.textContent.includes(searchText)) {
        box.parentElement.classList.add("select");
      }

      searchField.addEventListener("click", () => {
        searchText.value = "";
        box.parentElement.classList.remove("select");
      });
    });
  }
}
