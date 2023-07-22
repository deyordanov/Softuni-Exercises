function attachEventsListeners() {
  const input = document.querySelector("#inputDistance");
  const fromType = document.querySelector("#inputUnits");
  const toType = document.querySelector("#outputUnits");
  const button = document.querySelector("#convert");
  const output = document.querySelector("#outputDistance");

  const converter = {
    km: (value, type) => (type === "toM" ? value * 1000 : value / 1000),
    m: (value, type) => value,
    cm: (value, type) => (type === "toM" ? value / 100 : value * 100),
    mm: (value, type) => (type === "toM" ? value / 1000 : value * 1000),
    mi: (value, type) => (type === "toM" ? value * 1609.344 : value / 1609.344),
    yrd: (value, type) =>
      type === "toM" ? value / 1.0936133 : value * 1.0936133,
    ft: (value, type) =>
      type === "toM" ? value / 3.2808399 : value * 3.2808399,
    in: (value, type) =>
      type === "toM" ? value / 39.3700787 : value * 39.3700787,
  };

  button.addEventListener("click", callConverter);

  function callConverter() {
    const value = Number(input.value);
    const fromTypeValue = fromType.value;
    const toTypeValue = toType.value;
    const valueInM = converter[fromTypeValue](value, "toM");
    const convertedValue = converter[toTypeValue](valueInM, "notM");
    output.value = convertedValue;
  }
}
