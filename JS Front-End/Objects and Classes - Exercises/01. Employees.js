function createPerson(input) {
  const people = input.reduce((acc, curr) => {
    return { ...acc, [curr]: curr.length };
  }, {});

  Object.entries(people).forEach(([key, value]) =>
    console.log(`Name: ${key} -- Personal Number: ${value}`)
  );
}
