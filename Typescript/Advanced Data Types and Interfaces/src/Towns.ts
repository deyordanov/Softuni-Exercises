type Town = {
  city: string;
  latitude: string;
  longitude: string;
};

const getTowns = (towns: string[]): Town[] =>
  towns.reduce((acc, town) => {
    const [city, latitude, longitude] = town.split(" | ");
    acc.push({
      city,
      latitude,
      longitude,
    } as Town);
    return acc;
  }, []);

console.log(
  getTowns(["Sofia | 42.696552 | 23.32601", "Beijing | 39.913818 | 116.363625"])
);

console.log(getTowns(["Plovdiv | 136.45 | 812.575"]));
