function buyBitcoin(days) {
  let dayOfFirstBoughtBTC = 0;
  let btcBought = 0;
  let money = 0;
  let btcPrice = 11949.16;
  let goldPrice = 67.51;
  for (let i = 0; i < days.length; i++) {
    if ((i + 1) % 3 === 0) {
      days[i] -= days[i] * 0.3;
    }

    money += days[i] * goldPrice;
    if (money >= btcPrice) {
      if (dayOfFirstBoughtBTC === 0) {
        dayOfFirstBoughtBTC = i + 1;
      }

      while (money >= btcPrice) {
        money -= btcPrice;
        btcBought++;
      }
    }
  }

  console.log(`Bought bitcoins: ${btcBought}`);
  if (dayOfFirstBoughtBTC > 0) {
    console.log(`Day of the first purchased bitcoin: ${dayOfFirstBoughtBTC}`);
  }
  console.log(`Left money: ${money.toFixed(2)} lv.`);
}
