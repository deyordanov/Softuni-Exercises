import { useParams, Link } from "react-router-dom";
import { useState, useEffect } from "react";

const baseUrl = "https://swapi.dev/api/starships";

//Imagine we make a call to an API and retrieve all startships the character has ever driven
export default function CharacterStarships() {
    const { characterId } = useParams();
    const [starships, setStarships] = useState([]);

    useEffect(() => {
        fetch(baseUrl)
            .then((response) => response.json())
            .then((data) => setStarships(data.results));
    }, [characterId]);

    return (
        <>
            {starships.map((x) => (
                <div key={x.url}>
                    <Link
                        to={`/starships/${x.url
                            .split("/")
                            .filter((x) => x)
                            .pop()}`}
                    >
                        {x.name}
                    </Link>
                </div>
            ))}
        </>
    );
}
