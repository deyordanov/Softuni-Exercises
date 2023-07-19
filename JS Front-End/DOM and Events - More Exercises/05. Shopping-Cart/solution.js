function solve() {
  const products = {};

  const addButtons = Array.from(document.querySelectorAll(".add-product"));
  addButtons.forEach((addButton) => {
    addButton.addEventListener("click", buyItem);
  });

  const result = document.querySelector("textarea");

  const checkoutButton = document.querySelector(".checkout");
  checkoutButton.addEventListener("click", getTotal);

  //////////////////////////////////////////////////

  function buyItem(e) {
    const price = Number(
      e.currentTarget.parentElement.parentElement.querySelector(
        ".product-line-price"
      ).textContent
    ).toFixed(2);

    const name = e.currentTarget.parentElement.parentElement.querySelector(
      ".product-details .product-title"
    ).textContent;

    if (!products.hasOwnProperty(name)) {
      products[name] = [];
    }

    products[name].push(price);

    result.textContent += `Added ${name} for ${price} to the cart.\n`;
  }

  function getTotal() {
    result.textContent += `You bought ${Object.keys(products).join(
      ", "
    )} for ${Object.keys(products)
      .reduce((acc, curr) => {
        products[curr].forEach((price) => {
          acc += Number(price);
        });
        return acc;
      }, 0)
      .toFixed(2)}.`;

    disableAllButtons();
  }

  function disableAllButtons() {
    const buttons = document.querySelectorAll("button");
    buttons.forEach((button) => (button.disabled = true));
  }
}
