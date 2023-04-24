function countOccurrences(text, word) {
  let occurrences = text.split(" ").filter((e) => e === word).length;
  console.log(occurrences);
}

