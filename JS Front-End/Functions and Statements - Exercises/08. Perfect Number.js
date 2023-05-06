function getPerfectNumber(number) {
  let sumOfDividors = 0;
  for (let i = 1; i < number; i++) {
    if (number % i == 0) {
      sumOfDividors += i;
    }
  }

  console.log(
    sumOfDividors === number
      ? "We have a perfect number!"
      : "It's not so perfect."
  );
}
