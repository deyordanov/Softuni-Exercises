var getSecondHalfSorted = function (numbers) {
    var arrayLength = numbers.length / 2;
    return numbers.sort(function (a, b) { return a - b; }).slice(arrayLength);
};
console.log(getSecondHalfSorted([4, 7, 2, 5]));
console.log(getSecondHalfSorted([3, 19, 14, 7, 2, 19, 6]));
