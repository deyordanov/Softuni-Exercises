function solve(args) {
  const result = args.reduce((acc, curr, idx) => {
    if (idx % 2 === 0) {
      acc[curr] = 0;
    } else {
      acc[args[idx - 1]] = curr;
    }
    return acc;
  }, {});

  console.log(
    `{ ${Object.entries(result)
      .map((entry) => `${entry[0]}: ${entry[1]}`)
      .join(", ")} }`
  );
}
