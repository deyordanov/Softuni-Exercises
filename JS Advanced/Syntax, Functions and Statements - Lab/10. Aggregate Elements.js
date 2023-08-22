function solve(arr) {
  console.log(arr.reduce((acc, curr) => acc + curr));
  console.log(arr.map((num) => 1 / num).reduce((acc, curr) => acc + curr));
  console.log(arr.concat().join(""));
}
