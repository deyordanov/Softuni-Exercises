function findPalindromes(numbers) {
  numbers = numbers.map(String);
  for (let i = 0; i < numbers.length; i++) {
    if (numbers[i] === numbers[i].split("").reverse().join("")) {
      console.log("true");
    } else {
      console.log("false");
    }
  }
}
