function calculator(num1, num2, op) {
  const operations = {
    multiply: (num1, num2) => num1 * num2,
    divide: (num1, num2) => num1 / num2,
    add: (num1, num2) => num1 + num2,
    subtract: (num1, num2) => num1 - num2,
  };

  console.log(operations[op](num1, num2));
}
