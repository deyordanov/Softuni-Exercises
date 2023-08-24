function solve(car) {
  const engineSpecs = {
    90: 1800,
    120: 2400,
    200: 3500,
  };

  const newCar = {};
  const engine = {};
  const carriage = {};

  newCar.model = car.model;

  engine.power = Number(
    Object.keys(engineSpecs).filter((key) => car.power <= key)[0]
  );
  engine.volume = engineSpecs[engine.power];
  newCar.engine = engine;

  carriage.type = car.carriage;
  carriage.color = car.color;
  newCar.carriage = carriage;

  newCar.wheels = new Array(4).fill(
    car.wheelsize % 2 === 0 ? car.wheelsize - 1 : car.wheelsize
  );

  return newCar;
}
