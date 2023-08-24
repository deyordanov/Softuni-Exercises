function Catalogue(input) {
  const items = input.reduce((acc, curr) => {
    const [name, price] = curr.split(" : ");
    let letter = name[0];

    if (!acc[letter]) {
      acc[letter] = [];
    }

    acc[letter].push({ name, price });
    return acc;
  }, {});

  Object.keys(items)
    .sort()
    .forEach((letter) => {
      console.log(letter);
      items[letter]
        .sort((a, b) => a.name.localeCompare(b.name))
        .forEach((item) => {
          console.log(`  ${item.name}: ${item.price}`);
        });
    });
}
