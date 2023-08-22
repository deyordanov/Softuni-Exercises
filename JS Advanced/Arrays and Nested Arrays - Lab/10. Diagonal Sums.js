function solve(matrix) {
  let mainDiagonal = 0;
  let secondaryDiagonal = 0;
  for (let i = 0; i < matrix.length; i++) {
    mainDiagonal += matrix[i][i];
    secondaryDiagonal += matrix[i][matrix.length - 1 - i];
  }

  console.log(mainDiagonal, secondaryDiagonal);
}
