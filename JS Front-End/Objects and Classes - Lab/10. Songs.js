function createSongs(args) {
  const [_, ...songs] = args;
  const songType = songs.pop();
  class Song {
    constructor(type, name, time) {
      this.type = type;
      this.name = name;
      this.time = time;
    }
  }

  const result = songs
    .map((str) => {
      const [type, name, time] = str.split("_");
      const song = new Song(type, name, time);

      return song;
    })
    .filter((song) => {
      if (songType == "all") {
        return song;
      }

      return song.type === songType;
    })
    .map((song) => song.name)
    .join("\n");

  console.log(result);
}
