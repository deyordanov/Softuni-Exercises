type Person = {
  firstName: string;
  lastName: string;
  age: number;
};

const makePersonObject = (
  firstName: string,
  lastName: string,
  age: string
): Person => {
  return { firstName, lastName, age: Number(age) } as Person;
};

console.log(makePersonObject("Peter", "Pan", "20"));
console.log(makePersonObject("George", "Smith", "18"));
