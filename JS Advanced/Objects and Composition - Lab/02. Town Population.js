function solve(townArgs) {
  Object.entries(
    townArgs.reduce((acc, curr) => {
      const [name, population] = curr.split(" <-> ");
      if (!acc.hasOwnProperty(name)) {
        acc[name] = 0;
      }
      acc[name] += Number(population);
      return acc;
    }, {})
  ).forEach((value) => console.log(`${value[0]} : ${value[1]}`));
}
