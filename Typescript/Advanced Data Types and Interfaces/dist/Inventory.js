var Hero = /** @class */ (function () {
    function Hero(name, level, items) {
        this.name = name;
        this.level = level;
        this.items = items;
    }
    Hero.prototype.print = function () {
        console.log("Hero: ".concat(this.name));
        console.log("   Level => ".concat(this.level));
        console.log("   Items => ".concat(this.items.join(", ")));
        console.log("----------------------------------");
    };
    return Hero;
}());
var makeHeroInventory = function (input) {
    return input
        .reduce(function (acc, data) {
        var _a = data.split(" / "), heroName = _a[0], heroLevel = _a[1], heroItems = _a[2];
        acc.push(new Hero(heroName, Number(heroLevel), heroItems.split(", ")));
        return acc;
    }, [])
        .sort(function (a, b) { return a.level - b.level; });
};
console.log(makeHeroInventory([
    "Isacc / 25 / Apple, GravityGun",
    "Derek / 12 / BarrelVest, DestructionSword",
    "Hes / 1 / Desolator, Sentinel, Antara",
]).forEach(function (hero) { return hero.print(); }));
console.log(makeHeroInventory([
    "Batman / 2 / Banana, Gun",
    "Superman / 18 / Sword",
    "Poppy / 28 / Sentinel, Antara",
]).forEach(function (hero) { return hero.print(); }));
