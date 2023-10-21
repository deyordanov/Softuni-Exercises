import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";

const baseUrl = "https://swapi.dev/api/starships";

export default function Starship() {
    const { starshipId } = useParams();
    const [starship, setStarship] = useState({});

    useEffect(() => {
        fetch(`${baseUrl}/${starshipId}`)
            .then((response) => response.json())
            .then((data) => setStarship(data));
    }, [starshipId]);

    return <h1>{starship.name}</h1>;
}
