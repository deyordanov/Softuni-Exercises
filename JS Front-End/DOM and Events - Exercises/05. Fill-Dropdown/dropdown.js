function addItem() {
  const text = document.querySelector("#newItemText");
  const value = document.querySelector("#newItemValue");
  const option = document.createElement("option");
  option.textContent = `${text.value} ${value.value}`;
  document.querySelector("#menu").appendChild(option);
  value.value = "";
  text.value = "";
}
