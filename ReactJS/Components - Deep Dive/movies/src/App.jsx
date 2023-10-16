import "./App.css";
// import { movies as movieData } from "./movies";
import MovieList from "./Components/MovieList";
import { useState, useEffect } from "react";

function App() {
  // const [movies, setMovies] = useState(movieData);

  const [movies, setMovies] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5173/moviesJson.json")
      .then((response) => response.json())
      .then((movieData) => {
        console.log(movieData);
        setMovies(movieData);
      });
  }, []);

  const onMovieDelete = (id) => {
    setMovies((state) => state.filter((x) => x.id !== id));
  };

  const onMovieSelect = (id) => {
    setMovies((state) => state.map((x) => ({ ...x, selected: x.id === id })));
  };

  return (
    <div>
      <h1>Movie Collection:</h1>
      <MovieList
        movies={movies}
        onMovieDelete={onMovieDelete}
        onMovieSelect={onMovieSelect}
      />
    </div>
  );
}

export default App;
