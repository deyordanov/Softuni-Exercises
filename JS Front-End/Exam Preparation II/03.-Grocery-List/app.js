const urls = {
  BASE_URL: "http://localhost:3030/jsonstore/grocery",
};

const input = {
  name: document.querySelector("#product"),
  count: document.querySelector("#count"),
  price: document.querySelector("#price"),
};

const form = document.querySelector("form");
form.addEventListener("submit", (e) => e.preventDefault());

const addButton = document.querySelector("#add-product");
const updateButton = document.querySelector("#update-product");
const loadButton = document.querySelector("#load-product");

const tbody = document.querySelector("tbody");

addButton.addEventListener("click", addProduct);
loadButton.addEventListener("click", loadAllProducts);

function loadAllProducts() {
  tbody.innerHTML = "";

  fetch(urls.BASE_URL)
    .then((data) => data.json())
    .then((data) => {
      Object.keys(data).forEach((key) => {
        const row = createElement("tr", "", tbody, "");
        row.id = data[key]._id;

        createElement("td", data[key].product, row, "name");

        createElement("td", data[key].count, row, "count-product");

        createElement("td", data[key].price, row, "product-price");

        const buttonContainer = createElement("td", "", row, "btn");

        const updateBtn = createElement(
          "button",
          "Update",
          buttonContainer,
          "update"
        );
        updateBtn.addEventListener("click", updateProduct);

        const deleteBtn = createElement(
          "button",
          "Delete",
          buttonContainer,
          "delete"
        );
        deleteBtn.addEventListener("click", deleteProduct);
      });
    });
}

function addProduct() {
  fetch(urls.BASE_URL, {
    method: "POST",
    body: JSON.stringify({
      product: input.name.value,
      count: input.count.value,
      price: input.price.value,
    }),
  }).then(() => {
    Object.keys(input).forEach((key) => (input[key].value = ""));

    loadAllProducts();
  });
}

function deleteProduct(e) {
  const element = e.currentTarget.parentElement.parentElement;

  fetch(`${urls.BASE_URL}/${element.id}`, {
    method: "DELETE",
  }).then(() => {
    loadAllProducts();
  });
}

function updateProduct(e) {
  addButton.disabled = true;
  updateButton.disabled = false;
  const element = e.currentTarget.parentElement.parentElement;

  input.name.value = element.querySelector(":nth-child(1)").textContent;

  input.count.value = element.querySelector(":nth-child(2)").textContent;

  input.price.value = element.querySelector(":nth-child(3)").textContent;

  updateButton.addEventListener("click", updateRequest);

  function updateRequest() {
    addButton.disabled = false;
    updateButton.disabled = true;
    fetch(`${urls.BASE_URL}/${element.id}`, {
      method: "PATCH",
      body: JSON.stringify({
        product: input.name.value,
        count: input.count.value,
        price: input.price.value,
      }),
    }).then(() => {
      input.name.value = "";
      input.count.value = "";
      input.price.value = "";
      loadAllProducts();
    });
  }
}

function createElement(type, value, parent, cls) {
  const element = document.createElement(type);

  element.innerHTML = value;

  if (parent) {
    parent.appendChild(element);
  }

  if (cls) {
    element.classList.add(cls);
  }

  return element;
}
