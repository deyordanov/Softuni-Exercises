const urls = {
  BASE_URL: "http://localhost:3030/jsonstore/tasks",
};

const input = {
  name: document.querySelector("#name"),
  days: document.querySelector("#num-days"),
  date: document.querySelector("#from-date"),
};

const form = document.querySelector("form");
form.addEventListener("submit", (e) => e.preventDefault());
const loadButton = document.querySelector("#load-vacations");
const addVacationButton = document.querySelector("#add-vacation");
const editVacationButton = document.querySelector("#edit-vacation");
const list = document.querySelector("#list");

loadButton.addEventListener("click", loadHandler);
addVacationButton.addEventListener("click", addVacationHandler);

async function loadHandler() {
  list.innerHTML = "";
  const stream = await fetch(urls.BASE_URL);
  const data = await stream.json();

  Object.keys(data).forEach((key) => {
    const container = createElement("div", "", list, ["container"]);
    container.id = data[key]._id;

    createElement("h2", data[key].name, container, [""]);
    createElement("h3", data[key].date, container, [""]);
    createElement("h3", data[key].days, container, [""]);
    const changeButton = createElement("button", "Change", container, [
      "change-btn",
    ]);
    changeButton.addEventListener("click", changeHandler);

    const doneButton = createElement("button", "Done", container, ["done-btn"]);
    doneButton.addEventListener("click", doneHandler);

    function changeHandler(e) {
      const element = e.currentTarget.parentElement;
      list.removeChild(element);

      editVacationButton.disabled = false;
      addVacationButton.disabled = true;

      input.name.value = element.querySelector(":nth-child(1)").textContent;
      input.days.value = element.querySelector(":nth-child(3)").textContent;
      input.date.value = element.querySelector(":nth-child(2)").textContent;

      editVacationButton.addEventListener("click", async () => {
        await fetch(`${urls.BASE_URL}/${element.id}`, {
          method: "PATCH",
          body: JSON.stringify({
            name: input.name.value,
            days: input.days.value,
            date: input.date.value,
          }),
        });

        input.name.value = "";
        input.days.value = "";
        input.date.value = "";
        loadHandler();
        editVacationButton.disabled = true;
        addVacationButton.disabled = false;
      });
    }

    async function doneHandler(e) {
      const element = e.currentTarget.parentElement;

      await fetch(`${urls.BASE_URL}/${element.id}`, {
        method: "DELETE",
      });

      loadHandler();
    }
  });
}

async function addVacationHandler() {
  await fetch(urls.BASE_URL, {
    method: "POST",
    body: JSON.stringify({
      name: input.name.value,
      days: input.days.value,
      date: input.date.value,
    }),
  });

  input.name.value = "";
  input.days.value = "";
  input.date.value = "";
  loadHandler();
}

function createElement(type, value, parent, classes) {
  const element = document.createElement(type);

  element.innerHTML = value;

  if (parent) {
    parent.appendChild(element);
  }

  if (classes.length > 0 && classes[0] !== "") {
    classes.forEach((cls) => {
      element.classList.add(cls);
    });
  }

  return element;
}
