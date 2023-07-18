function addItem() {
  const list = document.getElementById("items");
  const text = document.getElementById("newItemText").value;
  const item = document.createElement("li");
  item.textContent = text;
  list.appendChild(item);
}
