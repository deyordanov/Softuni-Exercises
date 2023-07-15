function createMovies(commands) {
  const movies = [];
  for (let i = 0; i < commands.length; i++) {
    const command = commands[i];
    if (command.includes("addMovie")) {
      [_, name] = command.split("addMovie ");
      movies.push({
        name,
        director: null,
        date: null,
      });
    } else if (command.includes("directedBy")) {
      [name, director] = command.split(" directedBy ");
      const movie = movies.find((m) => m.name === name);

      if (movie) {
        movie.director = director;
      }
    } else if (command.includes("onDate")) {
      [name, date] = command.split(" onDate ");
      const movie = movies.find((m) => m.name === name);

      if (movie) {
        movie.date = date;
      }
    }
  }

  movies
    .filter((m) => m.name && m.date && m.director)
    .forEach((m) => console.log(JSON.stringify(m)));
}
