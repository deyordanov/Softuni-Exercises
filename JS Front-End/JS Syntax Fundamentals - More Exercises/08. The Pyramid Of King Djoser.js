function pyramid(base, increment) {
  let stone = 0;
  let marble = 0;
  let lapis = 0;
  let gold = 0;
  let level = 0;
  while (base - 2 >= 1) {
    level++;

    currentLevelStone = (base - 2) ** 2;
    stone += currentLevelStone;
    if (level % 5 === 0) {
      lapis += Math.pow(base, 2) - currentLevelStone;
    } else {
      marble += Math.pow(base, 2) - currentLevelStone;
    }

    base -= 2;
  }

  level++;
  gold += base ** 2;
  base -= 2;

  console.log(`Stone required: ${Math.ceil(stone * increment)}`);
  console.log(`Marble required: ${Math.ceil(marble * increment)}`);
  console.log(`Lapis Lazuli required: ${Math.ceil(lapis * increment)}`);
  console.log(`Gold required: ${Math.ceil(gold * increment)}`);
  console.log(`Final pyramid height: ${Math.floor(level * increment)}`);
}
