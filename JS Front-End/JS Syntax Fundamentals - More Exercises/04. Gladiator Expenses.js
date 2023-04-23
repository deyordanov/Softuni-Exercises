function armorRepairCost(fights, helmet, sword, shield, armor) {
  let cost = 0;
  for (let i = 1; i <= fights; i++) {
    if (i % 2 === 0) {
      cost += helmet;
    }

    if (i % 3 === 0) {
      cost += sword;
    }

    if (i % 6 === 0) {
      cost += shield;
    }

    if (i % 12 === 0) {
      cost += armor;
    }
  }
  console.log(`Gladiator expenses: ${cost.toFixed(2)} aureus`);
}
