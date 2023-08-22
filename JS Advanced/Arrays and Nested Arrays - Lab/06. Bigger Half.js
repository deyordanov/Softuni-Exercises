function solve(arr) {
  return arr.sort((f, s) => f - s).slice(arr.length / 2);
}
