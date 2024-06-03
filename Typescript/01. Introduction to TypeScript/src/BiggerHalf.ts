const getSecondHalfSorted = (numbers: number[]): number[] => {
  const arrayLength: number = numbers.length / 2;
  return numbers.sort((a, b) => a - b).slice(arrayLength);
};

console.log(getSecondHalfSorted([4, 7, 2, 5]));
console.log(getSecondHalfSorted([3, 19, 14, 7, 2, 19, 6]));
