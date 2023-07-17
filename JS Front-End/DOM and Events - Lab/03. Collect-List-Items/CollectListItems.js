function extractText() {
  const items = document.getElementsByTagName("li");
  const textarea = document.getElementById("result");
  for (let item of items) {
    textarea.value += item.textContent + "\n";
  }
}
