window.addEventListener("load", solve);

function solve() {
  const input = {
    name: document.querySelector("#student"),
    university: document.querySelector("#university"),
    score: document.querySelector("#score"),
  };
  const nextButton = document.querySelector("#next-btn");
  const list = document.querySelector("#preview-list");
  const listCandidates = document.querySelector("#candidates-list");

  nextButton.addEventListener("click", nextHandler);

  function nextHandler() {
    if (validate()) {
      const currentName = input.name.value;
      const currentUni = input.university.value;
      const currentScore = input.score.value;

      const container = createElement("li", "", list, ["application"]);

      const article = createElement("article", "", container, [""]);

      createElement("h4", currentName, article, [""]);
      createElement("p", `University: ${currentUni}`, article, [""]);
      createElement("p", `Score: ${currentScore}`, article, [""]);

      const editButton = createElement("button", "edit", container, [
        "action-btn",
        "edit",
      ]);
      editButton.addEventListener("click", edit);

      const applyButton = createElement("button", "apply", container, [
        "action-btn",
        "apply",
      ]);
      applyButton.addEventListener("click", apply);

      input.name.value = "";
      input.university.value = "";
      input.score.value = "";
      nextButton.disabled = true;

      function edit(e) {
        nextButton.disabled = false;
        const element = e.currentTarget.parentElement;
        list.removeChild(element);

        input.name.value = currentName;
        input.university.value = currentUni;
        input.score.value = currentScore;

        console.log(list);
      }
      function apply(e) {
        nextButton.disabled = false;
        const element = e.currentTarget.parentElement;
        list.removeChild(element);
        element.removeChild(editButton);
        element.removeChild(applyButton);
        listCandidates.appendChild(element);
      }
    }
  }

  function validate() {
    return Object.keys(input).reduce((acc, curr) => {
      if (input[curr].value === "") {
        acc = false;
      }
      return acc;
    }, true);
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
}
