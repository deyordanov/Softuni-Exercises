function findLargestNumber(...nums) {
  console.log(`The largest number is ${nums.sort((a, b) => b - a)[0]}.`);
}
