function circleArea(value) {
  if (typeof value === "number") {
    console.log((Math.PI * (value * value)).toFixed(2));
  } else {
    console.log(
      `We can not calculate the circle area, because we receive a ${typeof value}.`
    );
  }
}
