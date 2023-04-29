function getEveryWord(text) {
  console.log(text.match(/[A-Z]{1}[a-z]*/g).join(", "));
}
