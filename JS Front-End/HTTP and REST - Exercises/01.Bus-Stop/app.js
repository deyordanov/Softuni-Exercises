function getInfo() {
  const BASE_URL = "http://localhost:3030/jsonstore/bus/businfo/";
  const stopId = document.querySelector("#stopId").value;
  const stopName = document.querySelector("#stopName");
  const buses = document.querySelector("#buses");

  buses.innerHTML = "";
  fetch(`${BASE_URL}${stopId}`)
    .then((res) => res.json())
    .then((data) => {
      Object.keys(data.buses).forEach((key) => {
        const li = document.createElement("li");
        li.textContent = `Bus ${key} arrives in ${data.buses[key]} minutes`;
        buses.appendChild(li);
      });
      stopName.textContent = data.name;
    })
    .catch((err) => {
      stopName.textContent = "Error";
    });
}
