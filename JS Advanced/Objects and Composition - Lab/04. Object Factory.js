function factory(library, orders) {
  const obj = orders.reduce((acc, curr) => {
    const { template, parts } = curr;
    const newObj = {};
    newObj["name"] = template.name;
    parts.forEach((part) => {
      newObj[part] = library[part];
    });
    acc.push(newObj);
    return acc;
  }, []);

  return obj;
}
