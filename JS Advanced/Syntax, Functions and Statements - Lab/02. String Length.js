function solve(...arr) {
  const sum = arr.reduce((acc, curr) => {
    acc += curr.length;
    return acc;
  }, 0);
  console.log(sum);

  console.log(Math.round(sum / arr.length));
}
