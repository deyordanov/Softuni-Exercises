function cityTaxes(name, population, treasury) {
  const obj = {
    name,
    population,
    treasury,
    taxRate: 10,
    collectTaxes: function () {
      this.treasury += population * this.taxRate;
    },
    applyGrowth: function (percentage) {
      this.population += this.population * (percentage / 100);
    },
    applyRecession: function (percentage) {
      this.treasury -= this.treasury * (percentage / 100);
    },
  };

  return obj;
}
