function solve(input) {
  const count = Number(input.shift());
  const riders = input.splice(0, count).reduce((acc, curr) => {
    const [rider, fuelCapacity, position] = curr.split("|");
    acc[rider] = { fuelCapacity: Number(fuelCapacity), position };

    return acc;
  }, {});

  let end;
  while ((end = input.shift()) !== "Finish") {
    const command = end.split(" - ");
    switch (command.shift()) {
      case "StopForFuel":
        stop([...command]);
        break;
      case "Overtaking":
        overtake([...command]);
        break;
      case "EngineFail":
        fail([...command]);
        break;
    }
  }

  Object.keys(riders).forEach((key) => {
    console.log(key);
    console.log(`Final position: ${riders[key].position}`);
  });

  function stop([rider, minimumFuel, changedPosition]) {
    if (riders[rider].fuelCapacity < minimumFuel) {
      minimumFuel = Number(minimumFuel);
      riders[rider].position = changedPosition;
      console.log(
        `${rider} stopped to refuel but lost his position, now he is ${changedPosition}.`
      );
    } else {
      console.log(`${rider} does not need to stop for fuel!`);
    }
  }

  function overtake([rider1, rider2]) {
    const rider1P = Number(riders[rider1].position);
    const rider2P = Number(riders[rider2].position);
    if (rider1P < rider2P) {
      riders[rider1].position = rider2P;
      riders[rider2].position = rider1P;
      console.log(`${rider1} overtook ${rider2}!`);
    }
  }

  function fail([rider, lapsLeft]) {
    delete riders[rider];
    console.log(
      `${rider} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`
    );
  }
}
