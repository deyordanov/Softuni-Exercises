function solve([rows, cols, row, col]) {
  const matrix = new Array(rows).fill().map((a) => new Array(cols).fill(0));
  for (let r = 0; r < rows; r++) {
    for (let c = 0; c < cols; c++) {
      matrix[r][c] = Math.max(Math.abs(r - row), Math.abs(c - col)) + 1;
    }
  }
  console.log(matrix.map((arr) => arr.join(" ")).join("\n"));
}
