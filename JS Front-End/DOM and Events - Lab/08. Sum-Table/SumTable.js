function sumTable() {
  const elements = document.querySelectorAll("td:nth-child(even):not(#sum)");
  let sum = 0;
  for (let element of elements) {
    sum += Number(element.textContent);
  }

  const result = document.querySelector("#sum");
  result.textContent = sum;
}
