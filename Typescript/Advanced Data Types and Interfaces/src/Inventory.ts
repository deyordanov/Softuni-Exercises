type Item = string;

interface IHero {
  name: string;
  level: number;
  items: Item[];
  print: () => void;
}

class Hero implements IHero {
  name: string;
  level: number;
  items: Item[];

  constructor(name: string, level: number, items: Item[]) {
    this.name = name;
    this.level = level;
    this.items = items;
  }

  print() {
    console.log(`Hero: ${this.name}`);
    console.log(`   Level => ${this.level}`);
    console.log(`   Items => ${this.items.join(", ")}`);
    console.log(`----------------------------------`);
  }
}

const makeHeroInventory = (input: string[]): IHero[] =>
  input
    .reduce((acc: IHero[], data: string) => {
      const [heroName, heroLevel, heroItems] = data.split(" / ");
      acc.push(new Hero(heroName, Number(heroLevel), heroItems.split(", ")));
      return acc;
    }, [])
    .sort((a, b) => a.level - b.level);

console.log(
  makeHeroInventory([
    "Isacc / 25 / Apple, GravityGun",
    "Derek / 12 / BarrelVest, DestructionSword",
    "Hes / 1 / Desolator, Sentinel, Antara",
  ]).forEach((hero) => hero.print())
);

console.log(
  makeHeroInventory([
    "Batman / 2 / Banana, Gun",
    "Superman / 18 / Sword",
    "Poppy / 28 / Sentinel, Antara",
  ]).forEach((hero) => hero.print())
);
