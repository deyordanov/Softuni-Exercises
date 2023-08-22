function solve(matrix) {
  return matrix.reduce((acc, curr) => {
    const currBiggestNumber = Math.max(...curr);
    if (currBiggestNumber > acc) {
      acc = currBiggestNumber;
    }

    return acc;
  }, Number.MIN_SAFE_INTEGER - 1);
}
