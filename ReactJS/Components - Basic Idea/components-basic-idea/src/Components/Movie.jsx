import PropTypes from "prop-types";

const Movie = ({ title, year, cast }) => {
  return (
    <article>
      <h2>Title: {title}</h2>
      <p>Year: {year}</p>
      <p>Cast: {cast.join(", ")}</p>
    </article>
  );
};

Movie.propTypes = {
  title: PropTypes.string.isRequired,
  year: PropTypes.number.isRequired,
  cast: PropTypes.object.isRequired,
};

export default Movie;
