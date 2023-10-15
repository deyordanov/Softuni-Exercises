import PropTypes from "prop-types";

export default function Movie({
  title,
  year,
  director,
  genres,
  actors,
  plot,
  posterUrl,
}) {
  return (
    <article>
      <h3>{title}</h3>
      <main>
        <p>
          <b>Year:</b> {year}
        </p>
        <p>
          <b>Genres:</b> {genres.join(", ")}
        </p>
        <p>
          <b>Plot:</b> {plot}
        </p>
        <p>
          <b>Cast:</b> {actors}
        </p>
        <img src={posterUrl} alt={title} />
      </main>
      <footer>
        <p>
          <b>Author:</b> {director}
        </p>
      </footer>
    </article>
  );
}

Movie.propTypes = {
  title: PropTypes.string,
  year: PropTypes.string,
  director: PropTypes.string,
  genres: PropTypes.array,
  actors: PropTypes.string,
  plot: PropTypes.string,
  posterUrl: PropTypes.string,
};
