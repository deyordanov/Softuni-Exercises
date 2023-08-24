function solve(args) {
  const result = args.reduce((acc, curr) => {
    [name, level, items] = curr.split(" / ");
    acc.push({
      name,
      level: Number(level),
      items: items ? items.split(", ") : [],
    });
    return acc;
  }, []);
  console.log(JSON.stringify(result));
}
