var daysOfTheWeek = [
    "Monday",
    "Tuesday",
    "Wednesday",
    "Thursday",
    "Friday",
    "Saturday",
    "Sunday",
];
function isValidDayOfTheWeek(day) {
    var index = daysOfTheWeek.indexOf(day);
    console.log(index == -1 ? "error" : index + 1);
}
isValidDayOfTheWeek("Monday");
isValidDayOfTheWeek("Friday");
isValidDayOfTheWeek("Invalid");
