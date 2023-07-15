function subtract() {
  const inputs = Array.from(document.querySelectorAll("input"));
  console.log(inputs);
  inputs.forEach((input) => {
    input.removeAttribute("disabled");
    input.addEventListener("keyup", solve);
  });

  function solve() {
    const firstNumber = Number(document.querySelector("#firstNumber").value);
    const secondNumber = Number(document.querySelector("#secondNumber").value);
    const sum = firstNumber - secondNumber;

    document.querySelector("#result").textContent = sum;
  }
}
