const supportedOperations: string[] = ["+", "*", "-", "/", "%", "**"];

function sum(first: number, second: number, operation: string): number {
  if (!supportedOperations.some((op) => op == operation)) {
    console.error(`This operation is not supported: ${operation}`);
    return;
  }

  switch (operation) {
    case "+":
      return first + second;
    case "*":
      return first * second;
    case "-":
      return first - second;
    case "/":
      return first / second;
    case "%":
      return first % second;
    case "**":
      return Math.pow(first, second);
  }
}

console.log(sum(5, 6, "+"));
console.log(sum(3, 5.5, "*"));
console.log(sum(5, 2, "**"));
sum(2, 2, "Implement an integral operation!");
