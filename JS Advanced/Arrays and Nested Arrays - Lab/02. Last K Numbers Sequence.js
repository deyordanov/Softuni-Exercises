function solve(n, k) {
  const arr = [1];
  while (arr.length < n) {
    let number = 0;
    for (let i = arr.length - 1; i >= arr.length - k; i--) {
      if (i >= 0) {
        number += arr[i];
      }
    }
    arr.push(number);
  }

  return arr;
}
