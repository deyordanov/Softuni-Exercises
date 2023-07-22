function encodeAndDecodeMessages() {
  const [encodeButton, decodeButton] = Array.from(
    document.querySelectorAll("button")
  );
  let [input, output] = Array.from(document.querySelectorAll("textarea"));

  encodeButton.addEventListener("click", () => {
    let result = "";
    for (const letter of input.value) {
      result += String.fromCharCode(letter.charCodeAt(0) + 1);
    }
    input.value = "";
    output.value = result;
  });

  decodeButton.addEventListener("click", () => {
    let result = "";
    for (const letter of output.value) {
      result += String.fromCharCode(letter.charCodeAt(0) - 1);
    }
    output.value = result;
  });
}
