window.addEventListener("load", solve);

function solve() {
  const inputFields = {
    genre: document.querySelector("#genre"),
    name: document.querySelector("#name"),
    author: document.querySelector("#author"),
    date: document.querySelector("#date"),
  };

  const form = document.querySelector("form");
  form.addEventListener("submit", (e) => {
    e.preventDefault();
  });
  const addButton = document.querySelector("#add-btn");
  const songContainer = document.querySelector(".all-hits-container");
  const savedHits = document.querySelector(".saved-container");
  const likes = document.querySelector(".likes > p");

  addButton.addEventListener("click", addSong);

  function addSong() {
    if (fieldsNotEmpty()) {
      const container = createElement("div", "", songContainer);
      container.classList.add("hits-info");

      const image = createElement("img", "", container);
      image.src = "./static/img/img.png";

      createElement("h2", `Genre: ${inputFields.genre.value}`, container);

      createElement("h2", `Name: ${inputFields.name.value}`, container);

      createElement("h2", `Author: ${inputFields.author.value}`, container);

      createElement("h3", `Date: ${inputFields.date.value}`, container);

      const saveButton = createElement("button", "Save song", container);
      saveButton.classList.add("save-btn");
      saveButton.addEventListener("click", save);

      const likeButton = createElement("button", "Like song", container);
      likeButton.classList.add("like-btn");
      likeButton.addEventListener("click", like);

      const deleteButton = createElement("button", "Delete", container);
      deleteButton.classList.add("delete-btn");
      deleteButton.addEventListener("click", remove);

      Object.keys(inputFields).forEach((key) => {
        inputFields[key].value = "";
      });

      function remove(e) {
        const element = e.currentTarget.parentElement;
        e.currentTarget.parentElement.parentElement.removeChild(element);
      }

      function save(e) {
        const element = e.currentTarget.parentElement;
        songContainer.removeChild(element);

        element.removeChild(saveButton);
        element.removeChild(likeButton);

        savedHits.appendChild(element);
      }

      function like() {
        likeButton.disabled = true;
        const text = likes.textContent.split(" ");
        text[2] = Number(text[2]) + 1;
        likes.textContent = text.join(" ");
      }
    }
  }

  function fieldsNotEmpty() {
    return Object.keys(inputFields).reduce((acc, curr) => {
      if (inputFields[curr].value === "") {
        acc = false;
      }

      return acc;
    }, true);
  }

  function createElement(elementTag, value, parent) {
    const newElement = document.createElement(elementTag);
    newElement.innerHTML = value;
    if (parent) {
      parent.appendChild(newElement);
    }

    return newElement;
  }
}
