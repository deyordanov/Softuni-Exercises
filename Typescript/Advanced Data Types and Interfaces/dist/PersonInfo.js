var makePersonObject = function (firstName, lastName, age) {
    return { firstName: firstName, lastName: lastName, age: Number(age) };
};
console.log(makePersonObject("Peter", "Pan", "20"));
console.log(makePersonObject("George", "Smith", "18"));
