const getSum = (numbers: number[]): number =>
  numbers.reduce((acc: number, number: number) => (acc += number), 0);

const getInverseSum = (numbers: number[]): number =>
  numbers.reduce((acc: number, number: number) => (acc += 1 / number), 0);

const concatNumbers = (numbers: number[]): number =>
  Number(numbers.reduce((acc: string, number: number) => (acc += number), ""));

const aggregateElements = (numbers: number[]): number[] => [
  getSum(numbers),
  getInverseSum(numbers),
  concatNumbers(numbers),
];

console.log(aggregateElements([1, 2, 3]).join("\n"));
console.log(aggregateElements([2, 4, 8, 16]).join("\n"));
