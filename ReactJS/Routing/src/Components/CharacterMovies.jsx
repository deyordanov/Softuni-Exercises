import { useParams, Link } from "react-router-dom";
import { useState, useEffect } from "react";

const baseUrl = "https://swapi.dev/api/films";

//Imagine we make a call to an API and retrieve all movies the character is a part of
export default function CharacterMovies() {
    const { characterId } = useParams();
    const [movies, setMovies] = useState([]);

    useEffect(() => {
        fetch(baseUrl)
            .then((response) => response.json())
            .then((data) => setMovies(data.results));
    }, [characterId]);

    return (
        <>
            {movies.map((x) => (
                <div key={x.episode_id}>
                    <Link
                        to={`/movies/${x.url
                            .split("/")
                            .filter((x) => x)
                            .pop()}`}
                    >
                        {x.title}
                    </Link>
                </div>
            ))}{" "}
        </>
    );
}
