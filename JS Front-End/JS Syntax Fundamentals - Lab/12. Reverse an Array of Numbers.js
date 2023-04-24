function reverseArray(num, array) {
  let tempArr = array.slice(0, num);
  console.log(tempArr.reverse().join(" "));
}
