function solve(day) {
  const daysOfWeek = {
    Monday: 1,
    Tuesday: 2,
    Wednesday: 3,
    Thursday: 4,
    Friday: 5,
    Saturday: 6,
    Sunday: 7,
  };

  if (!daysOfWeek.hasOwnProperty(day)) {
    console.log("error");
    return;
  }

  console.log(daysOfWeek[day]);
}
