const getEmoloyeesWithPersonalNumber = (employees: string[]) => {
  return employees.reduce((acc: string[], name: string) => {
    const personalNumber = name.length;
    acc.push(`Name: ${name} -- Personal Number: ${personalNumber}`);
    return acc;
  }, []);
};

console.log(
  getEmoloyeesWithPersonalNumber([
    "Silas Butler",
    "Adnaan Buckley",
    "Juan Peterson",
    "Brendan Villarreal",
  ]).join("\n")
);

console.log(
  getEmoloyeesWithPersonalNumber([
    "Samuel Jackson",
    "Will Smith",
    "Bruce Willis",
    "Tom Holland",
  ]).join("\n")
);
