function solve(num1, num2, num3) {
  const sum = (x, y) => x + y;
  const subtract = (x, y) => x - y;
  console.log(subtract(sum(num1, num2), num3));
}
