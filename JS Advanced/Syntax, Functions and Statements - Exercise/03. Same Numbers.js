function solve(number) {
  const nums = Array.from(String(number));
  const num = nums[0];
  const sum = nums.map((n) => Number(n)).reduce((acc, curr) => acc + curr);

  console.log(nums.map((n) => n === num).includes(false) ? "false" : true);
  console.log(sum);
}
