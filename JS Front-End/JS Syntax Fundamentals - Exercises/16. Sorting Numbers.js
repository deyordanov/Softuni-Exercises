function sortNumbers(numbers) {
  numbers.sort((a, b) => a - b);
  let result = [];
  let index = 0;
  for (let i = 0; i < numbers.length; i++) {
    result[i] =
      i % 2 == 0 ? numbers[index] : numbers[numbers.length - 1 - index++];
  }

  return result;
}
