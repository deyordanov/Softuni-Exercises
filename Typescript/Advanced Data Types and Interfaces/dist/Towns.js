var getTowns = function (towns) {
    return towns.reduce(function (acc, town) {
        var _a = town.split(" | "), city = _a[0], latitude = _a[1], longitude = _a[2];
        acc.push({
            city: city,
            latitude: latitude,
            longitude: longitude,
        });
        return acc;
    }, []);
};
console.log(getTowns(["Sofia | 42.696552 | 23.32601", "Beijing | 39.913818 | 116.363625"]));
console.log(getTowns(["Plovdiv | 136.45 | 812.575"]));
