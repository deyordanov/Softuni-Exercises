function sumDigits(num) {
  let number = num.toString();
  let sum = 0;
  for (let i = 0; i < number.length; i++) {
    sum += Number(number[i]);
  }
  console.log(sum);
}
