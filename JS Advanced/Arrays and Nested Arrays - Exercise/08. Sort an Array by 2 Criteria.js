function solve(arr) {
  console.log(
    arr.sort((f, s) => f.length - s.length || f.localeCompare(s)).join("\n")
  );
}
