var createRegistry = function (input) {
    return input.reduce(function (acc, data) {
        var _a = data.split(" <-> "), name = _a[0], population = _a[1];
        acc.push({ name: name, population: population });
        return acc;
    }, []);
};
console.log(createRegistry([
    "Sofia <-> 1200000",
    "Montana <-> 20000",
    "New York <-> 10000000",
    "Washington <-> 2345000",
    "Las Vegas <-> 1000000",
]).forEach(function (town) { return console.log("".concat(town.name, " : ").concat(town.population)); }));
console.log(createRegistry([
    "Istanbul <-> 100000",
    "Honk Kong <-> 2100004",
    "Jerusalem <-> 2352344",
    "Mexico City <-> 23401925",
    "Istanbul <-> 1000",
]).forEach(function (town) { return console.log("".concat(town.name, " : ").concat(town.population)); }));
