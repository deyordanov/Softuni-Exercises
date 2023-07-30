function solve(elements) {
  const numberOfLines = Number(elements.shift());
  const pieces = elements.splice(0, numberOfLines).reduce((acc, curr) => {
    const [piece, composer, key] = curr.split("|");
    if (!acc.hasOwnProperty(piece)) {
      acc[piece] = { composer, key };
    }

    return acc;
  }, {});

  let end;
  while ((end = elements.shift()) != "Stop") {
    const command = end.split("|");
    switch (command.shift()) {
      case "Add":
        add([...command]);
        break;
      case "Remove":
        remove([...command]);
        break;
      case "ChangeKey":
        changeKey([...command]);
        break;
    }
  }

  Object.keys(pieces).forEach((piece) =>
    console.log(
      `${piece} -> Composer: ${pieces[piece].composer}, Key: ${pieces[piece].key}`
    )
  );

  function changeKey([piece, newKey]) {
    if (pieces.hasOwnProperty(piece)) {
      pieces[piece].key = newKey;
      console.log(`Changed the key of ${piece} to ${newKey}!`);
    } else {
      console.log(
        `Invalid operation! ${piece} does not exist in the collection.`
      );
    }
  }

  function remove([piece]) {
    if (pieces.hasOwnProperty(piece)) {
      delete pieces[piece];
      console.log(`Successfully removed ${piece}!`);
    } else {
      console.log(
        `Invalid operation! ${piece} does not exist in the collection.`
      );
    }
  }

  function add([piece, composer, key]) {
    if (!pieces.hasOwnProperty(piece)) {
      pieces[piece] = { composer, key };
      console.log(`${piece} by ${composer} in ${key} added to the collection!`);
    } else {
      console.log(`${piece} is already in the collection!`);
    }
  }
}
