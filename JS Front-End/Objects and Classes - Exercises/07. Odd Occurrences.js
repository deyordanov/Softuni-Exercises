function findOddOccurrences(text) {
  text = text.toLowerCase().split(" ");
  let keepOrderOfWords = [];
  const occurrences = text.reduce((acc, curr) => {
    if (!acc.hasOwnProperty(curr)) {
      acc[curr] = 0;
      keepOrderOfWords.push(curr);
    }

    acc[curr]++;

    return acc;
  }, {});

  keepOrderOfWords = keepOrderOfWords.filter((w) =>
    Object.keys(occurrences)
      .filter((key) => occurrences[key] % 2 !== 0)
      .includes(w)
  );
  console.log(keepOrderOfWords.join(" "));
}
