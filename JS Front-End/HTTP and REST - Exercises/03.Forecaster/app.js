function attachEvents() {
  const icons = {
    Sunny: "\u{2600}",
    "Partly sunny": "\u{26C5}",
    Overcast: "\u{2601}",
    Rain: "\u{2614}",
    Degrees: "\u{00B0}",
  };

  console.log(icons["Degrees"]);

  const urls = {
    LOCATION_BASE_URL: "http://localhost:3030/jsonstore/forecaster/locations",
    CURRENT_CONDITIONS_BASE_URL:
      "http://localhost:3030/jsonstore/forecaster/today/",
    UPCOMING_CONDITIONS_BASE_URL:
      "http://localhost:3030/jsonstore/forecaster/upcoming/",
  };
  const getWeatherButton = document.querySelector("#submit");
  const forecastContainer = document.querySelector("#forecast");
  const current = document.querySelector("#current");
  const upcoming = document.querySelector("#upcoming");

  getWeatherButton.addEventListener("click", getWeather);

  async function getWeather() {
    const location = document.querySelector("#location").value;
    const allLocationsStream = await fetch(urls.LOCATION_BASE_URL);
    const allLocationsData = await allLocationsStream.json();
    let locationData = {};
    allLocationsData.forEach((loc) => {
      if (loc.name === location) {
        locationData = loc;
      }
    });

    forecastContainer.style.display = "block";

    //////

    const currentStream = await fetch(
      `${urls.CURRENT_CONDITIONS_BASE_URL}${locationData.code}`
    );
    const currentData = await currentStream.json();

    current.appendChild(createCurrentWeatherConditionSection(currentData));

    ////////

    const upcomingStream = await fetch(
      `${urls.UPCOMING_CONDITIONS_BASE_URL}${locationData.code}`
    );
    const allUpcomingData = await upcomingStream.json();

    upcoming.appendChild(
      createUpcomingWeatherConditionSection(allUpcomingData)
    );
  }

  /////

  createUpcomingWeatherConditionSection = (allUpcomingData) => {
    const upcomingForecastContainer = document.createElement("div");
    upcomingForecastContainer.classList.add("forecast-info");

    allUpcomingData.forecast.forEach((upcomingData) => {
      upcomingForecastContainer.appendChild(
        createUpcomingWeatherConditionStatus(upcomingData)
      );
    });

    return upcomingForecastContainer;
  };

  createUpcomingWeatherConditionStatus = (upcomingData) => {
    const upcomingContainer = document.createElement("span");
    upcomingContainer.classList.add("upcoming");

    const icon = createIcon(upcomingData.condition);

    const upcomingTemp = document.createElement("span");
    upcomingTemp.classList.add("forecast-data");
    upcomingTemp.textContent = `${upcomingData.low}${icons["Degrees"]}/${upcomingData.high}${icons["Degrees"]}`;

    const upcomingCondition = document.createElement("span");
    upcomingCondition.classList.add("forecast-data");
    upcomingCondition.textContent = upcomingData.condition;

    upcomingContainer.appendChild(icon);
    upcomingContainer.appendChild(upcomingTemp);
    upcomingContainer.appendChild(upcomingCondition);

    return upcomingContainer;
  };

  ///////

  createCurrentWeatherConditionSection = (currentData) => {
    const currentForecastContainer = document.createElement("div");
    currentForecastContainer.classList.add("forecasts");

    currentForecastContainer.appendChild(
      createIcon(currentData.forecast.condition)
    );

    currentForecastContainer.appendChild(
      createCurrentWeatherConditionStatus(currentData)
    );

    console.log(currentForecastContainer);

    return currentForecastContainer;
  };

  createCurrentWeatherConditionStatus = (currentData) => {
    const currentContainer = document.createElement("span");
    currentContainer.classList.add("condition");

    const currentName = document.createElement("span");
    currentName.classList.add("forecast-data");
    currentName.textContent = currentData.name;

    const currentTemp = document.createElement("span");
    currentTemp.classList.add("forecast-data");
    currentTemp.textContent = `${currentData.forecast.low}${icons["Degrees"]}/${currentData.forecast.high}${icons["Degrees"]}`;

    const currentCondition = document.createElement("span");
    currentCondition.classList.add("forecast-data");
    currentCondition.textContent = currentData.forecast.condition;

    currentContainer.appendChild(currentName);
    currentContainer.appendChild(currentTemp);
    currentContainer.appendChild(currentCondition);

    return currentContainer;
  };

  createIcon = (type) => {
    const symbol = document.createElement("span");
    symbol.classList.add("condition", "symbol");
    symbol.textContent = icons[type];
    return symbol;
  };
}

attachEvents();
