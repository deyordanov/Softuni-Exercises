function printNthNumber(numbers, n) {
  let result = [];
  for (let i = 0; i < numbers.length; i += n) {
    result.push(numbers[i]);
  }

  return result;
}
