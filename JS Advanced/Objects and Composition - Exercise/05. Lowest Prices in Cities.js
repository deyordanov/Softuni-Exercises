function solve(args) {
  const result = args.reduce((acc, curr) => {
    const [town, product, price] = curr.split(" | ");
    if (!acc.hasOwnProperty(product)) {
      acc[product] = { town, price: Number(price) };
    }

    if (acc[product].price > Number(price)) {
      acc[product].town = town;
      acc[product].price = price;
    }

    return acc;
  }, {});
  console.log(
    Object.entries(result)
      .map((entry) => `${entry[0]} -> ${entry[1].price} (${entry[1].town})`)
      .join("\n")
  );
}
