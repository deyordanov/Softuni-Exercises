function calculatePrice(product, qty) {
  const prices = {
    coffee: 1.5,
    water: 1.0,
    coke: 1.4,
    snacks: 2.0,
  };

  console.log((prices[product] * qty).toFixed(2));
}
