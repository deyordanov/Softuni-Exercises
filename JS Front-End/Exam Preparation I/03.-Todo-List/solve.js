// TODO
function attachEvents() {
  const urls = {
    BASE_URL: "http://localhost:3030/jsonstore/tasks/",
  };

  const form = document.querySelector("form");
  const task = document.querySelector("#title");
  const addButton = document.querySelector("#add-button");
  const loadButton = document.querySelector("#load-button");
  const container = document.querySelector("#todo-list");

  form.addEventListener("submit", (e) => {
    e.preventDefault(); //bullshit

    addButton.addEventListener("click", add);

    loadButton.addEventListener("click", loadAll);
  });

  async function add() {
    await fetch(urls.BASE_URL, {
      method: "POST",
      body: JSON.stringify({ name: task.value }),
    });

    task.value = "";
    loadAll();
  }

  async function loadAll() {
    container.innerHTML = "";
    const stream = await fetch(urls.BASE_URL);
    const data = await stream.json();

    Object.keys(data).forEach((key) => {
      ({ name, _id } = data[key]);
      const item = document.createElement("li");
      item.id = _id;

      const taskName = document.createElement("span");
      taskName.textContent = name;

      const removeBtn = document.createElement("button");
      removeBtn.textContent = "Remove";
      removeBtn.addEventListener("click", remove);

      const editBtn = document.createElement("button");
      editBtn.textContent = "Edit";
      editBtn.addEventListener("click", edit);

      item.appendChild(taskName);
      item.appendChild(removeBtn);
      item.appendChild(editBtn);

      container.appendChild(item);
    });

    async function remove(e) {
      await fetch(`${urls.BASE_URL}${e.currentTarget.parentElement.id}`, {
        method: "DELETE",
      });

      loadAll();
    }

    async function edit(e) {
      const button = e.currentTarget;

      const spanElement = e.currentTarget.parentElement.querySelector("span");

      const item = e.currentTarget.parentElement;

      if (button.textContent == "Edit") {
        const input = document.createElement("input");
        input.value = spanElement.textContent;

        item.replaceChild(input, spanElement);
        button.textContent = "Submit";
      } else {
        await fetch(`${urls.BASE_URL}${item.id}`, {
          method: "PATCH",
          body: JSON.stringify({ name: item.querySelector("input").value }),
        });

        loadAll();
      }
    }
  }
}

attachEvents();
