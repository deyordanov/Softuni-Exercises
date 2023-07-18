function deleteByEmail() {
  const email = document.querySelector('input[name="email"]').value;
  const boxes = Array.from(document.querySelectorAll("td:nth-child(even)"));

  const boxToRemove = boxes.find((box) => box.textContent === email);
  const result = document.querySelector("#result");

  if (boxToRemove) {
    boxToRemove.parentElement.remove();
    result.textContent = "Deleted.";
  } else {
    result.textContent = "Not found.";
  }
}
