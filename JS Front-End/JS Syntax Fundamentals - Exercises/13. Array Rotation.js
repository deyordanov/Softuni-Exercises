function rotateArray(numbers, rotations) {
  for (let i = 0; i < rotations; i++) {
    numbers.splice(numbers.length - 1, 0, numbers.shift());
  }

  console.log(numbers.join(" "));
}
