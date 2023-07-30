function solve([input, ...commands]) {
  input = input.split("!");
  let end;
  while ((end = commands.shift()) != "Go Shopping!") {
    const command = end.split(" ");
    switch (command.shift()) {
      case "Urgent":
        if (!input.includes(command[0])) {
          input.unshift(command[0]);
        }
        break;
      case "Unnecessary":
        if (input.includes(command[0])) {
          const idx = input.indexOf(command[0]);
          input.splice(idx, 1);
        }
        break;
      case "Correct":
        if (input.includes(command[0])) {
          const idx = input.indexOf(command[0]);
          input.splice(idx, 1, command[1]);
        }
        break;
      case "Rearrange":
        if (input.includes(command[0])) {
          const idx = input.indexOf(command[0]);
          const deletedItem = input.splice(idx, 1);
          input.push(deletedItem[0]);
        }
        break;
    }
  }

  console.log(input.join(", "));
}
