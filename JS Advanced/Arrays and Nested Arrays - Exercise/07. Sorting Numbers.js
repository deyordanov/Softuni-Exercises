function solve(arr) {
  const sorted = [];
  arr.sort((f, s) => f - s);
  for (let i = 0; i <= arr.length + 2; i++) {
    sorted.push(arr.shift());
    sorted.push(arr.pop());
  }
  return sorted;
}
