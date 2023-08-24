function createAssemblyLine() {
  return {
    hasClima: function (car) {
      (car["temp"] = 21),
        (car["tempSettings"] = 21),
        (car["adjustTemp"] = function () {
          this.temp < this.tempSettings ? this.temp++ : this.temp--;
        });
    },
    hasAudio: function (car) {
      car["currentTrack"] = { name: null, artist: null };
      car["nowPlaying"] = function () {
        if (
          this.currentTrack.name !== null &&
          this.currentTrack.artist !== null
        ) {
          console.log(
            `Now playing '${this.currentTrack.name}' by ${this.currentTrack.artist}`
          );
        }
      };
    },
    hasParktronic: function (car) {
      car["checkDistance"] = function (distance) {
        if (distance < 0.1) {
          console.log("Beep! Beep! Beep!");
        } else if (0.1 <= distance && distance < 0.25) {
          console.log("Beep! Beep!");
        } else if (0.25 <= distance && distance < 0.5) {
          console.log("Beep!");
        } else {
          console.log();
        }
      };
    },
  };
}
