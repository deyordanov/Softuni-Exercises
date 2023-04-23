function extractWords(text) {
  let words = text.toUpperCase().match(/[A-Za-z0-9]+/g);
  console.log(words.join(", "));
}
