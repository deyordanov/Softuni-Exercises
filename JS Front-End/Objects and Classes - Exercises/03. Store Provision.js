function store(stock, ordered) {
  const currentStock = [...stock, ...ordered];
  const items = currentStock.reduce((acc, curr, i) => {
    if (i % 2 !== 0) {
      return acc;
    }

    if (!acc.hasOwnProperty(curr)) {
      acc[curr] = 0;
    }

    acc[curr] += Number(currentStock[i + 1]);
    return acc;
  }, {});

  Object.entries(items).forEach(([key, value]) =>
    console.log(`${key} -> ${value}`)
  );
}
