function solve(arr) {
  const newArr = [];
  arr.forEach((command, idx) => {
    command === "add" ? newArr.push(idx + 1) : newArr.pop();
  });
  console.log(newArr.length > 0 ? newArr.join("\n") : "Empty");
}
