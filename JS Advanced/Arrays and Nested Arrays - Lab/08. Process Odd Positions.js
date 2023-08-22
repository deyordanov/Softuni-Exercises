function solve(arr) {
  return arr
    .filter((num, idx) => idx % 2 !== 0)
    .map((num) => num * 2)
    .reverse();
}
