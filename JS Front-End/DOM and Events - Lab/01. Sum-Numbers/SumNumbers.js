function calc() {
  const first = document.getElementById("num1").value;
  const second = document.getElementById("num2").value;

  const result = Number(first) + Number(second);

  document.getElementById("sum").value = result;
}
