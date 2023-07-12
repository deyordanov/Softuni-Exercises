function createCats(input) {
  class Cat {
    constructor(name, age) {
      this.name = name;
      this.age = age;
    }

    meow = () => {
      console.log(`${this.name}, age ${this.age} says Meow`);
    };
  }

  const cats = [];
  for (let i = 0; i < input.length; i++) {
    const catData = input[i].split(" ");
    cats.push(new Cat(catData[0], catData[1]));
  }

  cats.forEach((kitty) => kitty.meow());
}
