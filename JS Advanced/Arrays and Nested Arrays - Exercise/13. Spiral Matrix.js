function solve(rows, cols) {
  const matrix = new Array(rows).fill().map(() => new Array(cols).fill(0));
  let rowIdx = 0;
  let colIdx = 0;
  let number = 1;
  while (rowIdx < rows && colIdx < cols) {
    for (let i = colIdx; i < cols; i++) {
      matrix[rowIdx][i] = number++;
    }
    rowIdx++;
    for (let i = rowIdx; i < rows; i++) {
      matrix[i][cols - 1] = number++;
    }
    cols--;
    if (rowIdx < rows) {
      for (let i = cols - 1; i >= colIdx; i--) {
        matrix[rows - 1][i] = number++;
      }
      rows--;
    }
    if (colIdx < cols) {
      for (let i = rows - 1; i >= rowIdx; i--) {
        matrix[i][colIdx] = number++;
      }
      colIdx++;
    }
  }

  console.log(matrix.map((arr) => arr.join(" ")).join("\n"));
}
