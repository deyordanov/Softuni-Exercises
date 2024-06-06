var getTownProducts = function (input) {
    return input.reduce(function (acc, data) {
        var _a = data.split(" | "), townName = _a[0], productName = _a[1], productPrice = _a[2];
        var product = acc.filter(function (town) { return town.productName === productName; })[0];
        if (!product) {
            acc.push({ townName: townName, productName: productName, productPrice: productPrice });
        }
        else if (product && Number(product.productPrice) > Number(productPrice)) {
            product.productPrice = productPrice;
            product.townName = townName;
        }
        return acc;
    }, []);
};
console.log(getTownProducts([
    "Sample Town | Sample Product | 1000",
    "Sample Town | Orange | 2",
    "Sample Town | Peach | 1",
    "Sofia | Orange | 3",
    "Sofia | Peach | 2",
    "New York | Sample Product | 1000.1",
    "New York | Burger | 10",
]).forEach(function (town) {
    return console.log("".concat(town.productName, " -> ").concat(town.productPrice, " (").concat(town.townName, ")"));
}));
