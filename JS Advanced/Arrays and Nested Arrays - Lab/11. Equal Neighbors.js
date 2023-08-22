function solve(matrix) {
  let count = 0;
  matrix.forEach((arr, matrixIdx) => {
    arr.forEach((value, valueIdx) => {
      if (
        matrixIdx + 1 <= matrix.length - 1 &&
        matrix[matrixIdx][valueIdx] === matrix[matrixIdx + 1][valueIdx]
      )
        count++;
      if (
        valueIdx + 1 <= matrix.length - 1 &&
        matrix[matrixIdx][valueIdx] === matrix[matrixIdx][valueIdx + 1]
      )
        count++;
    });
  });
  
  return count;
}
