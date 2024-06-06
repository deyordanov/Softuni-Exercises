// Catterface = Cat Interface :D
interface Catterface {
  name: string;
  age: number;
  meow(): string;
}

class Cat implements Catterface {
  name: string;
  age: number;

  constructor(name: string, age: number) {
    this.name = name;
    this.age = age;
  }

  meow(): string {
    return `${this.name}, age ${this.age} says "Meow".`;
  }
}

const makeCats = (data: string[]): Catterface[] =>
  data.reduce((accumulator: Catterface[], data: string) => {
    const [name, age] = data.split(" ");
    accumulator.push(new Cat(name, Number(age)));
    return accumulator;
  }, []);

makeCats(["Mellow 2", "Tom 5"]).forEach((cat) => console.log(cat.meow()));
makeCats(["Candy 1", "Poppy 3", "Nyx 2"]).forEach((cat) =>
  console.log(cat.meow())
);
