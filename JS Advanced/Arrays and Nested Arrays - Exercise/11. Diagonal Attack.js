function solve(matrix) {
  matrix = matrix.reduce((acc, curr) => {
    acc.push(curr.split(" ").map((num) => Number(num)));
    return acc;
  }, []);
  const diagonals = {};

  const { primarySum, secondarySum } = calculateDiagonalSums();

  if (primarySum === secondarySum) {
    for (let row = 0; row < matrix.length; row++) {
      for (let col = 0; col < matrix.length; col++) {
        if (!diagonals[row].includes(col)) {
          matrix[row][col] = primarySum;
        }
      }
    }
  }

  printMatrix();

  function printMatrix() {
    for (let row = 0; row < matrix.length; row++) {
      console.log(matrix[row].join(" "));
    }
  }

  function calculateDiagonalSums() {
    let primarySum = 0;
    let secondarySum = 0;
    for (let i = 0; i < matrix.length; i++) {
      primarySum += matrix[i][i];
      secondarySum += matrix[i][matrix.length - 1 - i];
      diagonals[i] = [];
      diagonals[i].push(i, matrix.length - 1 - i);
    }
    return { primarySum, secondarySum };
  }
}
