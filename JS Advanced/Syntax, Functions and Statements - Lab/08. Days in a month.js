function solve(month, year) {
  const func = (month, year) => new Date(year, month, 0).getDate();

  console.log(func(month, year));
}
