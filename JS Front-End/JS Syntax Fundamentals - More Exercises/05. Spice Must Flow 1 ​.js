function mineSpice(spice) {
  let days = 0;
  let spiceMined = 0;
  while (spice >= 100) {
    days++;
    spiceMined += spice;
    spice -= 10;

    spiceMined = spiceMined < 26 ? 0 : spiceMined - 26;
  }

  console.log(days);
  console.log(spiceMined >= 26 ? spiceMined - 26 : 0);
}
