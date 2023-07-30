window.addEventListener("load", solve);

function solve() {
  const inputFields = {
    firstName: document.querySelector("#first-name"),
    lastName: document.querySelector("#last-name"),
    age: document.querySelector("#age"),
    storyTitle: document.querySelector("#story-title"),
    genre: document.querySelector("#genre"),
    story: document.querySelector("#story"),
  };

  const publishButton = document.querySelector("#form-btn");
  publishButton.addEventListener("click", getData);

  function getData() {
    const inputValues = {
      FNV: inputFields.firstName.value,
      LNV: inputFields.lastName.value,
      AV: inputFields.age.value,
      STV: inputFields.storyTitle.value,
      GV: inputFields.genre.value,
      SV: inputFields.story.value,
    };

    const isValid = validateInput(inputFields);

    if (isValid) {
      publishButton.disabled = true;
      const list = document.querySelector("#preview-list");

      const item = document.createElement("li");
      item.classList.add("story-info");

      const container = document.createElement("article");

      const name = document.createElement("h4");
      name.textContent = `Name: ${inputValues.FNV} ${inputValues.LNV}`;

      const age = document.createElement("p");
      age.textContent = `Age: ${inputValues.AV}`;

      const title = document.createElement("p");
      title.textContent = `Title: ${inputValues.STV}`;

      const genre = document.createElement("p");
      genre.textContent = `Genre: ${inputValues.GV}`;

      const story = document.createElement("p");
      story.textContent = inputValues.SV;

      Object.keys(inputFields).forEach((key) => (inputFields[key].value = ""));

      container.appendChild(name);
      container.appendChild(age);
      container.appendChild(title);
      container.appendChild(genre);
      container.appendChild(story);

      const saveButton = document.createElement("button");
      saveButton.classList.add("save-btn");
      saveButton.textContent = "Save Story";
      saveButton.addEventListener("click", save);

      const editButton = document.createElement("button");
      editButton.classList.add("edit-btn");
      editButton.textContent = "Edit Story";
      editButton.addEventListener("click", edit);

      const deleteButton = document.createElement("button");
      deleteButton.classList.add("delete-btn");
      deleteButton.textContent = "Delete Story";
      deleteButton.addEventListener("click", remove);

      item.appendChild(container);
      item.appendChild(saveButton);
      item.appendChild(editButton);
      item.appendChild(deleteButton);
      list.appendChild(item);

      function edit() {
        publishButton.disabled = false;
        list.innerHTML = "<h3>Preview</h3>";
        inputFields.firstName.value = inputValues.FNV;
        inputFields.lastName.value = inputValues.LNV;
        inputFields.age.value = inputValues.AV;
        inputFields.storyTitle.value = inputValues.STV;
        inputFields.genre.value = inputValues.GV;
        inputFields.story.value = inputValues.SV;
      }

      function save() {
        const main = document.querySelector("#main");

        const title = document.createElement("h1");

        title.textContent = "Your scary story is saved!";

        main.innerHTML = "";
        main.appendChild(title);
      }

      function remove() {
        list.innerHTML = "<h3>Preview</h3>";
        publishButton.disabled = false;
      }
    }
  }

  validateInput = (inputFields) =>
    Object.keys(inputFields).reduce((acc, curr) => {
      if (inputFields[curr].value === "") {
        acc = false;
      }

      return acc;
    }, true);
}
