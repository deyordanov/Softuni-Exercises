function createHeroes(heroData) {
  const heroes = heroData.map((hero) => {
    const [name, level, itemsData] = hero.split(" / ");
    const items = itemsData.split(", ");
    return { name, level, items };
  });

  heroes
    .sort((a, b) => a.level - b.level)
    .forEach((h) =>
      console.log(
        `Hero: ${h.name}\nlevel => ${h.level}\nitems => ${h.items.join(", ")}`
      )
    );
}
