function solve(arr, count) {
  for (let i = 0; i < count; i++) {
    arr.unshift(arr.pop());
  }
  console.log(arr.join(" "));
}
