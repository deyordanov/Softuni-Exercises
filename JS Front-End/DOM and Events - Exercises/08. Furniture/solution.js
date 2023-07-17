function solve() {
  const buttonGenerate = document.querySelector("#exercise button");
  const table = document.querySelector("tbody");
  buttonGenerate.addEventListener("click", create);

  const buyButton = document.querySelectorAll("#exercise button")[1];
  const result = document.querySelectorAll("#exercise textarea")[1];

  buyButton.addEventListener("click", calculatePrice);

  function calculatePrice() {
    const checkedBoxes = Array.from(
      document.querySelectorAll('input[type="checkbox"]')
    ).filter((checkbox) => checkbox.checked);

    if (checkedBoxes.length > 0) {
      printResultInTextarea(result, checkedBoxes);
    }
  }

  /////

  function create() {
    const input = JSON.parse(
      document.querySelector("#exercise textarea").value
    );
    input.forEach((furniture) => {
      table.appendChild(createRow(furniture));
    });
  }

  function createImageCell(src) {
    const imageCell = document.createElement("td");
    const image = document.createElement("img");
    image.src = src;
    imageCell.appendChild(image);

    return imageCell;
  }

  function createTextCell(text) {
    const textCell = document.createElement("td");
    const paragraph = document.createElement("p");
    paragraph.textContent = text;
    textCell.appendChild(paragraph);

    return textCell;
  }

  function createCheckboxCell() {
    const checkboxCell = document.createElement("td");
    const checkbox = document.createElement("input");
    checkbox.type = "checkbox";
    checkboxCell.appendChild(checkbox);

    return checkboxCell;
  }

  function createRow(furniture) {
    const row = document.createElement("tr");
    row.appendChild(createImageCell(furniture.img));
    row.appendChild(createTextCell(furniture.name));
    row.appendChild(createTextCell(furniture.price));
    row.appendChild(createTextCell(furniture.decFactor));
    row.appendChild(createCheckboxCell());

    return row;
  }

  /////

  function printResultInTextarea(result, checkedBoxes) {
    result.textContent += `Bought furniture: ${getNames(checkedBoxes).join(
      ", "
    )}\n`;
    result.textContent += `Total price: ${getPrice(checkedBoxes).toFixed(2)}\n`;
    result.textContent += `Average decoration factor: ${getDecor(
      checkedBoxes
    )}`;
  }

  function getNames(checkedBoxes) {
    const names = checkedBoxes.reduce((acc, curr) => {
      acc.push(
        curr.parentElement.parentElement.querySelector(":nth-child(2) p")
          .textContent
      );
      return acc;
    }, []);

    return names;
  }

  function getPrice(checkedBoxes) {
    const sum = checkedBoxes.reduce((acc, curr) => {
      acc += Number(
        curr.parentElement.parentElement.querySelector(":nth-child(3)")
          .innerText
      );
      return acc;
    }, 0);

    return sum;
  }

  function getDecor(checkedBoxes) {
    const decor =
      checkedBoxes.reduce((acc, curr) => {
        acc += Number(
          curr.parentElement.parentElement.querySelector(":nth-child(4)")
            .innerText
        );
        return acc;
      }, 0) / checkedBoxes.length;

    return decor;
  }
}
