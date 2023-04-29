function substring(word, text) {
  textArr = text.toLowerCase().split(" ");
  const result = textArr.includes(word.toLowerCase());

  console.log(result === true ? word : `${word} not found!`);
}
