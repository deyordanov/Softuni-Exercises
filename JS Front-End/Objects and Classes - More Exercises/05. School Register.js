function register(input) {
  let schoolRegister = input.reduce((acc, curr) => {
    const [name, grade, averageScore] = curr
      .split([", "])
      .join(": ")
      .split(": ")
      .filter((x, i) => i % 2 !== 0);

    if (averageScore > 3) {
      if (!acc[grade]) {
        acc[grade] = [];
      }

      acc[grade].push({ name, averageScore });
    }
    return acc;
  }, {});

  Object.keys(schoolRegister)
    .sort((grade) => schoolRegister[grade].averageScore)
    .forEach((grade) => {
      console.log(`${Number(grade) + 1} Grade`);
      console.log(
        `List of students: ${schoolRegister[grade]
          .map((s) => s.name)
          .join(", ")}`
      );
      console.log(
        `Average annual score from last year: ${(
          schoolRegister[grade]
            .map((s) => s.averageScore)
            .reduce((acc, curr) => {
              return (acc += Number(curr));
            }, 0) / schoolRegister[grade].length
        ).toFixed(2)}`
      );
      console.log();
    });
}
