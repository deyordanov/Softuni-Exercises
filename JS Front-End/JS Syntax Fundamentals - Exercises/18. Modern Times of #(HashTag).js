function getWordsThatContainHashTag(text) {
  const reg = /\#[A-Za-z]+/g;
  let arr = text.match(reg).map((w) => w.slice(1));
  arr.forEach((w) => console.log(w));
}
