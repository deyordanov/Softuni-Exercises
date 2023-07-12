function phoneBook(people) {
  const book = people.reduce((acc, curr) => {
    const [name, phone] = curr.split(" ");
    return { ...acc, [name]: phone };
  }, {});

  Object.entries(book).forEach(([key, value]) =>
    console.log(`${key} -> ${value}`)
  );
}
