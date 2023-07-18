function addItem() {
  const items = document.querySelector("#items");
  const item = document.createElement("li");
  const text = document.querySelector("#newItemText").value;
  item.textContent = text;
  const deleteButton = document.createElement("a");
  deleteButton.href = "#";
  deleteButton.textContent = "[Delete]";
  item.appendChild(deleteButton);
  deleteButton.addEventListener("click", (e) => {
    e.target.parentElement.remove();
  });
  items.appendChild(item);
}
