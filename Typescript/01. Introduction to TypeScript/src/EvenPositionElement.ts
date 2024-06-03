const getEvenNumbers = (numbers: string[]): string[] => {
  return numbers.filter((n, index) => index % 2 === 0);
};

console.log(getEvenNumbers(["20", "30", "40", "50", "60"]).join(" "));
