function solve() {
  return {
    mage: function (name) {
      return {
        name,
        health: 100,
        mana: 100,
        cast: function (spell) {
          console.log(`${this.name} cast ${spell}`);
          this.mana--;
        },
      };
    },
    fighter: function (name) {
      return {
        name,
        health: 100,
        stamina: 100,
        fight: function () {
          console.log(`${this.name} slashes at the foe!`);
          this.stamina--;
        },
      };
    },
  };
}
