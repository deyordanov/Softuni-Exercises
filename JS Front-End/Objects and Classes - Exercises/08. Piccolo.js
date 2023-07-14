function parking(commands) {
  const cars = new Set();
  commands.forEach((entry) => {
    const [command, car] = entry.split(", ");
    if (command === "IN") {
      cars.add(car);
    } else if (command === "OUT") {
      cars.delete(car);
    }
  });

  let a = Array.from(cars)
    .sort()
    .forEach((n) => console.log(n));
}
