function solve(num1, num2) {
  for (let i = Math.max(num1, num2); i >= 0; i--) {
    if (num1 % i === 0 && num2 % i === 0) {
      console.log(i);
      return;
    }
  }
}
