function meetings(people) {
  const schedule = people.reduce((acc, curr) => {
    const [day, name] = curr.split(" ");
    if (acc.hasOwnProperty(day)) {
      console.log(`Conflict on ${day}!`);
      return acc;
    }

    console.log(`Scheduled for ${day}`);
    return { ...acc, [day]: name };
  }, {});

  Object.entries(schedule).forEach(([key, value]) =>
    console.log(`${key} -> ${value}`)
  );
}
