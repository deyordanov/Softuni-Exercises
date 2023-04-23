function calculator(num1, sign, num2) {
  switch (sign) {
    case "+":
      console.log((num1 + num2).toFixed(2));
      break;
    case "-":
      console.log((num1 - num2).toFixed(2));
      break;
    case "/":
      console.log((num1 / num2).toFixed(2));
      break;
    case "*":
      console.log((num1 * num2).toFixed(2));
      break;
  }
}
