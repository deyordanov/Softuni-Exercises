var getEvenNumbers = function (numbers) {
    return numbers.filter(function (n, index) { return index % 2 === 0; });
};
console.log(getEvenNumbers(["20", "30", "40", "50", "60"]).join(" "));
