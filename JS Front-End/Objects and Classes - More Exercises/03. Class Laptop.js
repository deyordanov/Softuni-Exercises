class Laptop {
  constructor(info, quality) {
    this.info = info;
    this.quality = quality;
    this.isOn = false;
  }

  turnOn() {
    this.isOn = true;
    this.quality--;
  }

  turnOff() {
    this.isOn = false;
    this.quality--;
  }

  showInfo() {
    return JSON.stringify(this.info);
  }

  get price() {
    return 800 - Number(this.info.age) * 2 + this.quality * 0.5;
  }
}
