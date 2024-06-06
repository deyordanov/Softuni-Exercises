var Food = /** @class */ (function () {
    function Food(name, calories) {
        this.name = name;
        this.calories = calories;
    }
    return Food;
}());
var createFoodObjects = function (input) {
    var result = [];
    for (var i = 0; i < input.length; i += 2) {
        result.push(new Food(input[i], Number(input[i + 1])));
    }
    return result;
};
console.log(createFoodObjects(["Yoghurt", "48", "Rise", "138", "Apple", "52"]));
console.log(createFoodObjects([
    "Potato",
    "93",
    "Skyr",
    "63",
    "Cucumber",
    "18",
    "Milk",
    "42",
]));
