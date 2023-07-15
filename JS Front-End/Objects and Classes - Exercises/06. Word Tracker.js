function findOccurrences([searchWords, ...words]) {
  searchWords = searchWords.split(" ");
  const wordsOccurrences = searchWords.reduce((acc, curr) => {
    acc[curr] = 0;

    return acc;
  }, {});

  words.forEach((word) => {
    if (wordsOccurrences.hasOwnProperty(word)) {
      wordsOccurrences[word]++;
    }
  });

  Object.keys(wordsOccurrences)
    .sort((key1, key2) => wordsOccurrences[key2] - wordsOccurrences[key1])
    .forEach((key) => console.log(`${key} - ${wordsOccurrences[key]}`));
}
