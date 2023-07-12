function getPeoplesAdresses(people) {
  const adresses = people.reduce((acc, curr) => {
    const [name, adress] = curr.split(":");
    return { ...acc, [name]: adress };
  }, {});

  Object.keys(adresses)
    .sort((a, b) => a.localeCompare(b))
    .forEach((key) => console.log(`${key} -> ${adresses[key]}`));
}
