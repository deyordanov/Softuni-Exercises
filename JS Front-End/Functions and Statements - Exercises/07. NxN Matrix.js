function printMatrix(size) {
  let matrix = [];
  for (let row = 0; row < size; row++) {
    matrix[row] = [];
    for (let col = 0; col < size; col++) {
      matrix[row][col] = size;
    }
  }

  for (let row = 0; row < size; row++) {
    console.log(matrix[row].join(" "));
  }
}
