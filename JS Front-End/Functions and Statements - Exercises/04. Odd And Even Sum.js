function sumOddAndEven(number) {
  number = String(number).split("").map(Number);
  let sumEven = 0;
  let sumOdd = 0;
  number.forEach((n) => (n % 2 == 0 ? (sumEven += n) : (sumOdd += n)));
  console.log(`Odd sum = ${sumOdd}, Even sum = ${sumEven}`);
}
