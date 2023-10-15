import "../movies";
import PropTypes from "prop-types";
import Movie from "./Movie";

export default function MovieList({ movies, onMovieDelete, onMovieSelect }) {
  const reactMovies = movies.map((m) => (
    <Movie
      key={m.id}
      {...m}
      onMovieDelete={onMovieDelete}
      onMovieSelect={onMovieSelect}
    />
  ));

  return reactMovies;
}

MovieList.propTypes = {
  movies: PropTypes.array,
  onMovieDelete: PropTypes.func,
  onMovieSelect: PropTypes.func,
};
