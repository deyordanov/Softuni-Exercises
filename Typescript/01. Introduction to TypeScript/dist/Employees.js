var getEmoloyeesWithPersonalNumber = function (employees) {
    return employees.reduce(function (acc, name) {
        var personalNumber = name.length;
        acc.push("Name: ".concat(name, " -- Personal Number: ").concat(personalNumber));
        return acc;
    }, []);
};
console.log(getEmoloyeesWithPersonalNumber([
    "Silas Butler",
    "Adnaan Buckley",
    "Juan Peterson",
    "Brendan Villarreal",
]).join("\n"));
console.log(getEmoloyeesWithPersonalNumber([
    "Samuel Jackson",
    "Will Smith",
    "Bruce Willis",
    "Tom Holland",
]).join("\n"));
