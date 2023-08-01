window.addEventListener("load", solve);

function solve() {
  const input = {
    title: document.querySelector("#title"),
    description: document.querySelector("#description"),
    label: document.querySelector("#label"),
    points: document.querySelector("#points"),
    assignee: document.querySelector("#assignee"),
  };

  const symbols = {
    feature: { code: "8865", cls: "feature" },
    "low priority bug": { code: "9737", cls: "low-priority" },
    "high priority bug": { code: "9888", cls: "high-priority" },
  };

  const form = document.querySelector("form");
  form.addEventListener("submit", (e) => e.preventDefault());
  const createButton = document.querySelector("#create-task-btn");
  const deleteButton = document.querySelector("#delete-task-btn");
  const taskSection = document.querySelector("#tasks-section");
  const points = document.querySelector("#total-sprint-points");

  createButton.addEventListener("click", createTask);

  function createTask() {
    if (validateInput()) {
      const currentTitle = input.title.value;
      const currentDesc = input.description.value;
      const currentLabel = input.label.value;
      const currentPoints = input.points.value;
      const currentAssignee = input.assignee.value;

      const increasedPoints = points.textContent.split(" ");
      increasedPoints[2] =
        Number(increasedPoints[2].split("pts")[0]) + Number(currentPoints);
      points.textContent = `${increasedPoints[0]} ${increasedPoints[1]} ${increasedPoints[2]}pts`;

      const container = createElement("article", "", taskSection, [
        "task-card",
      ]);
      container.id = `task-${taskSection.querySelectorAll("article").length}`;

      createElement(
        "div",
        `${currentLabel} ${String.fromCharCode(
          symbols[currentLabel.toLowerCase()].code
        )}`,
        container,
        ["task-card-label", symbols[currentLabel.toLowerCase()].cls]
      );

      createElement("h3", currentTitle, container, ["task-card-title"]);

      createElement("p", currentDesc, container, ["task-card-description"]);

      createElement("div", `Estimated at ${currentPoints} pts`, container, [
        "task-card-points",
      ]);

      createElement("div", `Assigned to: ${currentAssignee}`, container, [
        "task-card-assignee",
      ]);

      const div = createElement("div", "", container, ["task-card-actions"]);

      const deleteBtn = createElement("button", "Delete", div, "");
      deleteBtn.addEventListener("click", remove);

      Object.keys(input).forEach((key) => (input[key].value = ""));

      function remove(e) {
        const element = e.currentTarget.parentElement.parentElement;

        createButton.disabled = true;
        deleteButton.disabled = false;

        input.title.value = currentTitle;
        input.description.value = currentDesc;
        input.label.value = currentLabel;
        input.points.value = currentPoints;
        input.assignee.value = currentAssignee;

        Object.keys(input).forEach((key) => (input[key].disabled = true));

        document.querySelector('input[type="hidden"]').value = element.id;

        deleteButton.addEventListener("click", () => {
          taskSection.removeChild(element);
          Object.keys(input).forEach((key) => {
            input[key].value = "";
            input[key].disabled = false;
          });
          createButton.disabled = false;
          deleteButton.disabled = true;

          const decreasePoints = points.textContent.split(" ");
          decreasePoints[2] =
            Number(decreasePoints[2].split("pts")[0]) - Number(currentPoints);
          points.textContent = `${decreasePoints[0]} ${decreasePoints[1]} ${decreasePoints[2]}pts`;
        });
      }
    }
  }

  function createElement(type, value, parent, classes) {
    const newElement = document.createElement(type);

    newElement.innerHTML = value;

    if (parent) {
      parent.appendChild(newElement);
    }

    if (classes) {
      classes.forEach((cls) => newElement.classList.add(cls));
    }

    return newElement;
  }

  function validateInput() {
    return Object.keys(input).reduce((acc, curr) => {
      if (input[curr].value === "") {
        acc = false;
      }

      return acc;
    }, true);
  }
}
