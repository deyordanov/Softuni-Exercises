type Product = {
  townName: string;
  productName: string;
  productPrice: string;
};

const getTownProducts = (input: string[]): Product[] =>
  input.reduce((acc: Product[], data: string) => {
    const [townName, productName, productPrice] = data.split(" | ");
    const product = acc.filter((town) => town.productName === productName)[0];
    if (!product) {
      acc.push({ townName, productName, productPrice } as Product);
    } else if (product && Number(product.productPrice) > Number(productPrice)) {
      product.productPrice = productPrice;
      product.townName = townName;
    }
    return acc;
  }, []);

console.log(
  getTownProducts([
    "Sample Town | Sample Product | 1000",
    "Sample Town | Orange | 2",
    "Sample Town | Peach | 1",
    "Sofia | Orange | 3",
    "Sofia | Peach | 2",
    "New York | Sample Product | 1000.1",
    "New York | Burger | 10",
  ]).forEach((town) =>
    console.log(
      `${town.productName} -> ${town.productPrice} (${town.townName})`
    )
  )
);
