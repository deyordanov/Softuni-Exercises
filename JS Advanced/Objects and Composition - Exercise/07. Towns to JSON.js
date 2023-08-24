function solve(args) {
  args.shift();
  return JSON.stringify(
    args.reduce((acc, curr) => {
      const [Town, Latitude, Longitude] = curr
        .split("|")
        .map((x) => x.trim())
        .filter((x) => x !== "" && x !== " ");
      const obj = {
        Town,
        Latitude: Number(Number(Latitude).toFixed(2)),
        Longitude: Number(Number(Longitude).toFixed(2)),
      };
      acc.push(obj);
      return acc;
    }, [])
  );
}
