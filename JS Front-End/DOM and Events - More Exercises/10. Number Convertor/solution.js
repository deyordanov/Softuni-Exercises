function solve() {
  const obj = {
    button: document.querySelector("button"),
    toDropDownMenu: document.querySelector("#selectMenuTo"),
    result: document.querySelector("#result"),
  };

  obj.toDropDownMenu.appendChild(createOptions("binary"));
  obj.toDropDownMenu.appendChild(createOptions("hexadecimal"));

  obj.button.addEventListener("click", convert);

  function convert() {
    obj.convertTo = document.querySelector("#selectMenuTo").value;

    if (obj.convertTo != "") {
      obj.number = Number(document.querySelector("#input").value);
      obj.result.value = createConvertor()[obj.convertTo](obj.number);
    }
  }

  function createOptions(value) {
    const option = document.createElement("option");
    option.textContent = `${value.charAt(0).toUpperCase()}${value.slice(1)}`;
    option.setAttribute("value", value);

    return option;
  }

  function createConvertor() {
    return {
      binary: (convert = (dec) => (dec >>> 0).toString(2)),
      hexadecimal: (convert = (dec) => dec.toString(16).toUpperCase()),
    };
  }
}
