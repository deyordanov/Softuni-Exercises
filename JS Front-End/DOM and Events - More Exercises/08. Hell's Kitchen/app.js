function solve() {
  document.querySelector("#btnSend").addEventListener("click", onClick);

  function onClick() {
    const obj = {
      input: JSON.parse(document.querySelector("#inputs textarea").value),
      bestRestaurantResult: document.querySelector("#bestRestaurant p"),
      bestWorkersResult: document.querySelector("#workers p"),
    };

    const restaurants = obj.input.reduce((acc1, curr1) => {
      const [rtrtName, workers] = curr1.split(" - ");
      if (!acc1.hasOwnProperty(rtrtName)) {
        acc1[rtrtName] = {};
      }
      workers.split(", ").forEach((worker) => {
        const [workerName, salary] = worker.split(" ");
        acc1[rtrtName][workerName] = Number(salary);
      });

      acc1[rtrtName]["avgSalary"] = 0;
      Object.keys(acc1[rtrtName])
        .filter((key) => key != "avgSalary")
        .forEach((key) => {
          acc1[rtrtName]["avgSalary"] +=
            acc1[rtrtName][key] / (Object.keys(acc1[rtrtName]).length - 1);
        });

      return acc1;
    }, {});

    const bestRtrtName = Object.keys(restaurants).sort(
      (key1, key2) =>
        restaurants[key2]["avgSalary"] - restaurants[key1]["avgSalary"]
    )[0];

    const bestWorkers = Object.keys(restaurants[bestRtrtName])
      .filter((key) => key != "avgSalary")
      .sort(
        (key1, key2) =>
          restaurants[bestRtrtName][key2] - restaurants[bestRtrtName][key1]
      );

    obj.bestRestaurantResult.textContent = `Name: ${bestRtrtName} Average Salary: ${restaurants[
      bestRtrtName
    ]["avgSalary"].toFixed(2)} Best Salary: ${restaurants[bestRtrtName][
      bestWorkers[0]
    ].toFixed(2)}`;

    obj.bestWorkersResult.textContent = bestWorkers
      .map(
        (key) => `Name: ${key} With Salary: ${restaurants[bestRtrtName][key]}`
      )
      .join(" ");
  }
}
