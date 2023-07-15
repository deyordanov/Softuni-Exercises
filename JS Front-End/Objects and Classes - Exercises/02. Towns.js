function createCity(input) {
  const cities = input.map((city) => {
    const data = city.split(" | ");
    const town = data[0];
    const latitude = Number(data[1]).toFixed(2);
    const longitude = Number(data[2]).toFixed(2);
    return { town, latitude, longitude };
  });

  cities.forEach((city) =>
    console.log(
      `{ town: '${city.town}', latitude: '${city.latitude}', longitude: '${city.longitude}' }`
    )
  );
}
