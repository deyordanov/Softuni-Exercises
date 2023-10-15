import "./App.css";
import { movies } from "./movies";
import MovieList from "./Components/MovieList";

function App() {
  return (
    <div>
      <h1>Movie Collection:</h1>

      <MovieList movies={movies.slice(0, 30)} />
    </div>
  );
}

export default App;
