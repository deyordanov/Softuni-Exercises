import PropTypes from "prop-types";
import { useEffect } from "react";
import MovieCSS from "./Style/Movie.module.css";
import classNames from "classnames";

export default function Movie({
  id,
  title,
  year,
  director,
  genres,
  actors,
  plot,
  posterUrl,
  onMovieDelete,
  onMovieSelect,
  selected,
}) {
  //Component lifecylces (3):

  useEffect(() => {
    console.log(`${title} has been mounted!`);
  }, [title]);

  useEffect(() => {
    console.log(`${title} has been updated!`);
  }, [selected, title]);

  useEffect(() => {
    return () => {
      console.log(`${title} has been unmounted!`);
    };
  }, [title]);

  //Using the 'classnames' package to "clean up" the process of adding classes to elements
  //If we add to the classNames()
  //Object - (key -> the name of the class we want, value -> the condition on which we want to add it)
  //String - we will always add that class
  //StringArray - we will always add all of those classes
  //Add by: npm install classnames
  const selectedWrapperClass = classNames({ "movie-selected": selected });

  return (
    <article>
      <h3 className={MovieCSS[selectedWrapperClass]}>{title}</h3>
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
      <button onClick={() => onMovieDelete(id)}>Delete</button>
      <button onClick={() => onMovieSelect(id)}>Select</button>
    </article>
  );
}

Movie.propTypes = {
  id: PropTypes.number,
  title: PropTypes.string,
  year: PropTypes.string,
  director: PropTypes.string,
  genres: PropTypes.array,
  actors: PropTypes.string,
  plot: PropTypes.string,
  posterUrl: PropTypes.string,
  onMovieDelete: PropTypes.func,
  onMovieSelect: PropTypes.func,
  selected: PropTypes.bool,
};
