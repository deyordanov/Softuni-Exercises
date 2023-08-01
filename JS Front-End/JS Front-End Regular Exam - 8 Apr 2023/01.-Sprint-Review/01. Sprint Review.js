function solve(input) {
  const count = Number(input.shift());
  const initialState = input.splice(0, count);
  const people = initialState.reduce((acc, curr) => {
    const [assignee, taskId, title, status, estimatedPoints] = curr.split(":");

    if (!acc.hasOwnProperty(assignee)) {
      acc[assignee] = [];
    }

    acc[assignee].push({
      taskId,
      title,
      status,
      estimatedPoints: Number(estimatedPoints),
    });

    return acc;
  }, {});

  input.forEach((command) => {
    cmdArgs = command.split(":");
    switch (cmdArgs.shift()) {
      case "Add New":
        add([...cmdArgs]);
        break;
      case "Change Status":
        change([...cmdArgs]);
        break;
      case "Remove Task":
        remove([...cmdArgs]);
        break;
    }
  });

  const toDoPoints = getPoints("ToDo");
  const inProgressPoints = getPoints("In Progress");
  const codeReviewPoints = getPoints("Code Review");
  const donePoints = getPoints("Done");
  console.log(`ToDo: ${toDoPoints}pts`);
  console.log(`In Progress: ${inProgressPoints}pts`);
  console.log(`Code Review: ${codeReviewPoints}pts`);
  console.log(`Done Points: ${donePoints}pts`);

  console.log(
    donePoints >= inProgressPoints + codeReviewPoints + toDoPoints
      ? "Sprint was successful!"
      : "Sprint was unsuccessful..."
  );

  function add([assignee, taskId, title, status, estimatedPoints]) {
    if (isAssigneeValid(assignee)) {
      people[assignee].push({
        taskId,
        title,
        status,
        estimatedPoints: Number(estimatedPoints),
      });
    }
  }

  function change([assignee, taskId, newStatus]) {
    if (isAssigneeValid(assignee) && isTaskIdValid(assignee, taskId)) {
      people[assignee].find((task) => task.taskId == taskId).status = newStatus;
    }
  }

  function remove([assignee, index]) {
    index = Number(index);
    if (isAssigneeValid(assignee) && isIndexValid(assignee, index)) {
      people[assignee].splice(index, 1);
    }
  }

  function getPoints(statusType) {
    return Object.values(people).reduce((acc, curr) => {
      return (acc += curr
        .filter((task) => task.status === statusType)
        .map((task) => task.estimatedPoints)
        .reduce((total, points) => (total += points), 0));
    }, 0);
  }

  function isAssigneeValid(name) {
    const isValid = Object.keys(people).includes(name);

    if (!isValid) {
      console.log(`Assignee ${name} does not exist on the board!`);
    }

    return isValid;
  }

  function isTaskIdValid(name, taskId) {
    const isValid = people[name].some((task) => task.taskId === taskId);

    if (!isValid) {
      console.log(`Task with ID ${taskId} does not exist for ${name}!`);
    }

    return isValid;
  }

  function isIndexValid(name, index) {
    const isValid = index >= 0 && index < people[name].length;

    if (!isValid) {
      console.log(`Index is out of range!`);
    }

    return isValid;
  }
}
