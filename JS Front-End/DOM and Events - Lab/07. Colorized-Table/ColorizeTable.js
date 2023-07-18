function colorize() {
  const elements = document.querySelectorAll("tr:nth-child(even)");
  for (let element of elements) {
    element.style.backgroundColor = "Teal";
  }
}
