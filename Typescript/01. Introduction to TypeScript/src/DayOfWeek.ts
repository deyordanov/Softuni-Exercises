const daysOfTheWeek: string[] = [
  "Monday",
  "Tuesday",
  "Wednesday",
  "Thursday",
  "Friday",
  "Saturday",
  "Sunday",
];

function isValidDayOfTheWeek(day: string): void {
  const index: number = daysOfTheWeek.indexOf(day);
  console.log(index == -1 ? "error" : index + 1);
}

isValidDayOfTheWeek("Monday");
isValidDayOfTheWeek("Friday");
isValidDayOfTheWeek("Invalid");
