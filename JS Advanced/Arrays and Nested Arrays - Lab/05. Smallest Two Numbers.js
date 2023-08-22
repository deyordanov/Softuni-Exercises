function solve(arr) {
  arr.sort((f, s) => f - s);
  console.log(arr.shift(), arr.shift());
}
