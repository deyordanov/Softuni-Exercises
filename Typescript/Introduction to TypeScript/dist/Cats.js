var Cat = /** @class */ (function () {
    function Cat(name, age) {
        this.name = name;
        this.age = age;
    }
    Cat.prototype.meow = function () {
        return "".concat(this.name, ", age ").concat(this.age, " says \"Meow\".");
    };
    return Cat;
}());
var makeCats = function (data) {
    return data.reduce(function (accumulator, data) {
        var _a = data.split(" "), name = _a[0], age = _a[1];
        accumulator.push(new Cat(name, Number(age)));
        return accumulator;
    }, []);
};
makeCats(["Mellow 2", "Tom 5"]).forEach(function (cat) { return console.log(cat.meow()); });
makeCats(["Candy 1", "Poppy 3", "Nyx 2"]).forEach(function (cat) {
    return console.log(cat.meow());
});
