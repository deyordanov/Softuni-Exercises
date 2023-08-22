function solve(arr) {
  const newArr = [];
  arr.forEach((num) => {
    if (num < 0) {
      newArr.unshift(num);
    } else {
      newArr.push(num);
    }
  });

  console.log(newArr.join("\n"));
}
