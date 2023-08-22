function solve(value) {
  if (typeof value === "number") {
    console.log((Math.pow(Number(value), 2) * Math.PI).toFixed(2));
  } else {
    console.log(
      `We can not calculate the circle area, because we receive a ${typeof value}.`
    );
  }
}
