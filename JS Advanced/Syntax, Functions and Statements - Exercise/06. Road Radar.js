function roadRadar(speed, place) {
    const limits = {
      motorway: 130,
      interstate: 90,
      city: 50,
      residential: 20,
    };
  
    const speedOverLimit = speed - limits[place];
    if (speedOverLimit <= 0) {
      console.log(`Driving ${speed} km/h in a ${limits[place]} zone`);
      return;
    }
  
    const status =
      speedOverLimit <= 20
        ? "speeding"
        : speedOverLimit <= 40
        ? "excessive speeding"
        : "reckless driving";
  
    console.log(
      `The speed is ${speedOverLimit} km/h faster than the allowed speed of ${limits[place]} - ${status}`
    );
  }