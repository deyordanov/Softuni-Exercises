function sameNumbers(num) {
  const digits = Array.from(String(num), Number);
  const areEqual = new Set(digits).size === 1;
  const sum = digits.reduce((total, number) => total + number);

  console.log(areEqual);
  console.log(sum);
}
