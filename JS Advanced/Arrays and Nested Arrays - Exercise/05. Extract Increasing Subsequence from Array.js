function solve(arr) {
  let biggestNum = arr[0];
  return arr.reduce((acc, curr) => {
    if (curr >= biggestNum) {
      biggestNum = curr;
      acc.push(curr);
    }
    return acc;
  }, []);
}
