function solve() {
  const [checkBtn, reset] = Array.from(document.querySelectorAll("button"));
  const tableRows = Array.from(document.querySelectorAll("tbody > tr"));
  let tableBorder = document.querySelector("table");
  let out = document.querySelector("#check > p");
  let correctFill = true;
  let matrix = [];

  checkBtn.addEventListener("click", checkResult);
  reset.addEventListener("click", resetResult);

  function checkResult() {
    for (const items of tableRows) {
      let row = Array.from(items.querySelectorAll("td > input"));
      let rowData = [];
      for (let item of row) {
        let number = Number(item.value);
        rowData.push(number);
      }
      matrix.push(rowData);
    }

    checkColumns();
    if (correctFill) {
      tableBorder.style.border = "2px solid green";
      out.textContent = "You solve it! Congratulations!";
      out.style.color = "green";
    } else {
      tableBorder.style.border = "2px solid red";
      out.textContent = "NOP! You are not done yet...";
      out.style.color = "red";
    }
  }

  function resetResult() {
    tableRows.forEach((x) => {
      Array.from(x.querySelectorAll("td > input")).forEach((e) => {
        e.value = "";
      });
    });

    tableBorder.style.border = "";
    out.textContent = "";
    out.style.color = "";
  }

  function checkColumns() {
    for (let i = 0; i < matrix.length; i++) {
      let row = matrix[i];
      let col = matrix.map((row) => row[i]);
      if (
        col.length !== new Set(col).size ||
        row.length !== new Set(row).size
      ) {
        correctFill = false;
        break;
      }
    }
  }
}
