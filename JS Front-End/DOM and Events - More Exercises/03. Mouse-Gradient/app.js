function attachGradientEvents() {
  const gradient = document.querySelector("#gradient");
  gradient.addEventListener("mousemove", getCoordinates);
  gradient.addEventListener("mouseout", removeCoordinates);

  function getCoordinates(e) {
    let power = e.offsetX / (e.target.clientWidth - 1);
    power = Math.floor(power * 100);
    document.querySelector("#result").textContent = `${power}%`;
  }

  function removeCoordinates() {
    document.querySelector("#result").textContent = "";
  }
}
