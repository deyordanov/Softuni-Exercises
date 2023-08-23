function solve(names) {
  names.sort((f, s) => f.localeCompare(s));
  let num = 1;
  names.forEach((name) => console.log(`${num++}.${name}`));
}
