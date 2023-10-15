import "../movies";
import PropTypes from "prop-types";
import Movie from "./Movie";

export default function MovieList({ movies }) {
  const reactMovies = movies.map((m) => <Movie key={movies.id} {...m} />);

  return reactMovies;
}

MovieList.propTypes = {
  movies: PropTypes.array,
};
