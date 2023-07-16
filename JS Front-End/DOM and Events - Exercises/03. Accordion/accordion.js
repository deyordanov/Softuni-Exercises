function toggle() {
  const button = document.querySelector("span.button");
  const text = document.querySelector("#extra");
  text.style.display = text.style.display === "block" ? "none" : "block";
  button.textContent = button.textContent === "More" ? "Less" : "More";
}
