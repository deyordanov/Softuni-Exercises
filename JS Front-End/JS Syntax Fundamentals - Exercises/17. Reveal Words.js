function replaceWords(words, text) {
  let arr = words.split(", ");
  arr.forEach((w) => (text = text.replace("*".repeat(w.length), w)));

  console.log(text);
}
