function generateReport() {
  const indexes = [];
  const output = document.querySelector("#output");
  const tHeadRow = document.querySelector("thead").rows[0];
  Array.from(tHeadRow.children).forEach((header, i) => {
    if (header.children[0].checked) {
      indexes.push(i);
    }
  });

  const result = [];
  Array.from(document.querySelector("tbody").rows).forEach((row) => {
    const employee = {};
    Array.from(row.children).forEach((child, i) => {
      if (indexes.includes(i)) {
        employee[tHeadRow.children[i].children[0].getAttribute("name")] =
          child.textContent;
      }
    });
    result.push(employee);
  });

  output.textContent = JSON.stringify(result);
}
