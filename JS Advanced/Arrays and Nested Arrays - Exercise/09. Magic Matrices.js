function solve(matrix) {
  let isValid = true;
  for (let row = 0; row < matrix.length; row++) {
    const rowSum = matrix[row].reduce((acc, curr) => acc + curr);
    for (let col = 0; col < matrix.length; col++) {
      let colSum = 0;
      for (let i = 0; i < matrix.length; i++) {
        colSum += matrix[i][col];
      }

      if (rowSum !== colSum) {
        isValid = false;
      }
    }
  }
  console.log(isValid);
}
