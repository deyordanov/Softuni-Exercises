function flightSchedule(input) {
  let flights = input.shift().reduce((acc, curr) => {
    const [flight, city] = curr.split(" ");
    acc[flight] = { city, status: "Ready to fly" };
    return acc;
  }, {});

  input.shift().forEach((stat) => {
    const [flight, status] = stat.split(" ");
    if (flights[flight]) {
      flights[flight].status = status;
    }
  });

  const toPrint = input.shift();
  Object.keys(flights).forEach((flight) => {
    if (flights[flight].status == toPrint) {
      console.log(
        `{ Destination: '${flights[flight].city}', Status: '${flights[flight].status}' }`
      );
    }
  });
}
