import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

const baseUrl = "https://swapi.dev/api/films";

export default function Movie() {
    const { movieId } = useParams();
    const [movie, setMovie] = useState({});

    useEffect(() => {
        fetch(`${baseUrl}/${movieId}`)
            .then((response) => response.json())
            .then((data) => {
                console.log(data);
                setMovie(data);
            });
    }, [movieId]);

    return <h1>{movie.title}</h1>;
}
