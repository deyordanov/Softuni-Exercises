function vacation(people, type, day) {
  const prices = {
    Students: {
      Friday: 8.45,
      Saturday: 9.8,
      Sunday: 10.46,
      discount: (people, price) =>
        people >= 30 ? price - price * 0.15 : price,
    },

    Business: {
      Friday: 10.9,
      Saturday: 15.6,
      Sunday: 16,
      discount: (people, price) =>
        people >= 100 ? price - 10 * prices[type][day] : price,
    },

    Regular: {
      Friday: 15,
      Saturday: 20,
      Sunday: 22.5,
      discount: (people, price) =>
        people >= 10 && people <= 20 ? price - price * 0.05 : price,
    },
  };

  let price = prices[type][day] * people;
  price = prices[type].discount(people, price);

  console.log(`Total price: ${price.toFixed(2)}`);
}
