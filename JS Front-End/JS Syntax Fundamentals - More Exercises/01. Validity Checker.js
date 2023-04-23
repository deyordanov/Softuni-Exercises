function validate(x1, y1, x2, y2) {
  const calculateDistance = (x1, y1, x2, y2) =>
    Number.isInteger(Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2)));

  const print = (x1, y1, x2, y2) =>
    console.log(
      calculateDistance(x1, y1, x2, y2)
        ? `{${x1}, ${y1}} to {${x2}, ${y2}} is valid`
        : `{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`
    );

  print(x1, y1, 0, 0);
  print(x2, y2, 0, 0);
  print(x1, y1, x2, y2);
}
