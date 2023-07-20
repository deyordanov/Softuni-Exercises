function solve() {
  let text = Array.from(document.querySelector("#text").value.split(" ")).map(
    (word) => word.toLowerCase()
  );
  const convention = document.querySelector("#naming-convention").value;
  const result = document.querySelector("#result");

  result.textContent +=
    convention === "Pascal Case"
      ? PascalCase().join("")
      : convention === "Camel Case"
      ? camelCase().join("")
      : "Error!";

  function PascalCase() {
    makeFirstLetterUpperCase();
    return text;
  }

  function camelCase() {
    const firstWord = text.shift();
    makeFirstLetterUpperCase();
    text.unshift(firstWord);
    return text;
  }

  function makeFirstLetterUpperCase() {
    text = text.map((word) => {
      let chars = word.split("");
      chars[0] = chars[0].toUpperCase();
      word = chars.join("");
      return word;
    });
  }
}
