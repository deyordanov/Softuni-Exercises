type TownData = {
  name: string;
  population: string;
};

const createRegistry = (input: string[]): TownData[] =>
  input.reduce((acc, data) => {
    const [name, population] = data.split(" <-> ");
    acc.push({ name, population } as TownData);
    return acc;
  }, []);

console.log(
  createRegistry([
    "Sofia <-> 1200000",
    "Montana <-> 20000",
    "New York <-> 10000000",
    "Washington <-> 2345000",
    "Las Vegas <-> 1000000",
  ]).forEach((town) => console.log(`${town.name} : ${town.population}`))
);

console.log(
  createRegistry([
    "Istanbul <-> 100000",
    "Honk Kong <-> 2100004",
    "Jerusalem <-> 2352344",
    "Mexico City <-> 23401925",
    "Istanbul <-> 1000",
  ]).forEach((town) => console.log(`${town.name} : ${town.population}`))
);
