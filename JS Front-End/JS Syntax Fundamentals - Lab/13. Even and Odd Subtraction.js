function differenceBetweenEvenAndOdd(array) {
  let sumEven = 0;
  let sumOdd = 0;
  array.forEach((n) => (n % 2 == 0 ? (sumEven += n) : (sumOdd += n)));
  console.log(sumEven - sumOdd);
}
