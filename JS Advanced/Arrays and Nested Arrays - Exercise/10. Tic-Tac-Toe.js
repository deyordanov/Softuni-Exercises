function solve(coordinates) {
  const matrix = [
    [false, false, false],
    [false, false, false],
    [false, false, false],
  ];
  let count = Math.pow(matrix.length, 2);
  let symbol = "X";
  for (let idx = 0; idx < coordinates.length; idx++) {
    const [row, col] = coordinates[idx].split(" ").map((num) => Number(num));
    if (matrix[row][col] !== false) {
      console.log("This place is already taken. Please choose another!");
      continue;
    }

    matrix[row][col] = symbol;
    count--;

    if (checkForWinner(row, col, symbol)) {
      console.log(`Player ${symbol} wins!`);
      break;
    }

    if (count <= 0) {
      console.log("The game ended! Nobody wins :(");
      break;
    }

    symbol = symbol === "X" ? "O" : "X";
  }

  printMatrix();

  function checkForWinner(row, col, symbol) {
    if (
      (matrix[row][0] == symbol &&
        matrix[row][1] == symbol &&
        matrix[row][2] == symbol) ||
      (matrix[0][col] == symbol &&
        matrix[1][col] == symbol &&
        matrix[2][col] == symbol) ||
      (matrix[0][0] == symbol &&
        matrix[1][1] == symbol &&
        matrix[2][2] == symbol) ||
      (matrix[0][2] == symbol &&
        matrix[1][1] == symbol &&
        matrix[2][0] == symbol)
    ) {
      return true;
    }
    return false;
  }

  function printMatrix() {
    for (let r = 0; r < matrix.length; r++) {
      console.log(matrix[r].join("\t"));
    }
  }
}
