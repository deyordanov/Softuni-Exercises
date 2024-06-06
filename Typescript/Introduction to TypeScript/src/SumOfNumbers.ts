const printNumbers = (N: number, M: number): void => {
  let result: number = 0;
  for (let i: number = N; i <= M; i++) result += i;
  console.log(result);
};

// printNumbers(1, 5);
printNumbers(-8, 20);
