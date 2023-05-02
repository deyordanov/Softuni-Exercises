function solve(...nums) {
  const negativeNumebers = nums.filter((n) => n < 0).length;
  if (negativeNumebers === 2 || negativeNumebers === 0) {
    console.log("Positive");
    return;
  }
  console.log("Negative");
}
