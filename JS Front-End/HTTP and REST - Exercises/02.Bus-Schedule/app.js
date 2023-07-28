function solve() {
  const BASE_URL = " http://localhost:3030/jsonstore/bus/schedule/";
  let currentStop = "depot";
  let nextStop = "depot";
  const output = document.querySelector("#info .info");
  const departButton = document.querySelector("#depart");
  const arriveButton = document.querySelector("#arrive");
  async function depart() {
    const stream = await fetch(`${BASE_URL}${nextStop}`);
    const stopInfo = await stream.json();
    output.textContent = `Next stop ${stopInfo.name}`;
    currentStop = stopInfo.name;
    nextStop = stopInfo.next;
    departButton.setAttribute("disabled", true);
    arriveButton.removeAttribute("disabled");
  }

  async function arrive() {
    departButton.removeAttribute("disabled");
    arriveButton.setAttribute("disabled", true);
    output.textContent = `Arriving at ${currentStop}`;
  }

  return {
    depart,
    arrive,
  };
}

let result = solve();
