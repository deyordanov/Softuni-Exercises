function mathOperations(num1, num2, symbol) {
  switch (symbol) {
    case "+":
      console.log(num1 + num2);
      break;
    case "-":
      console.log(num1 - num2);
      break;
    case "*":
      console.log(num1 * num2);
      break;
    case "/":
      console.log(num1 / num2);
      break;
    case "%":
      console.log(num1 % num2);
      break;
    case "**":
      console.log(num1 ** num2);
      break;
  }
}
