function solve(args) {
  const operations = {
    "+": (num1, num2) => num1 + num2,
    "-": (num1, num2) => num1 - num2,
    "*": (num1, num2) => num1 * num2,
    "/": (num1, num2) => num1 / num2,
  };

  const result = args.reduce((acc, curr) => {
    if (!operations.hasOwnProperty(curr)) {
      acc.push(curr);
    } else {
      const first = acc.pop();
      const second = acc.pop();
      acc.push(operations[curr](second, first));
    }

    return acc;
  }, []);

  if (
    result.some((x) => Object.keys(operations).includes(x)) ||
    result.some((x) => !x)
  ) {
    console.log("Error: not enough operands!");
  } else if (result.length > 1) {
    console.log("Error: too many operands!");
  } else {
    console.log(result[0]);
  }
}

solve([15, "/"]);
