var getSum = function (numbers) {
    return numbers.reduce(function (acc, number) { return (acc += number); }, 0);
};
var getInverseSum = function (numbers) {
    return numbers.reduce(function (acc, number) { return (acc += 1 / number); }, 0);
};
var concatNumbers = function (numbers) {
    return Number(numbers.reduce(function (acc, number) { return (acc += number); }, ""));
};
var aggregateElements = function (numbers) { return [
    getSum(numbers),
    getInverseSum(numbers),
    concatNumbers(numbers),
]; };
console.log(aggregateElements([1, 2, 3]).join("\n"));
console.log(aggregateElements([2, 4, 8, 16]).join("\n"));
