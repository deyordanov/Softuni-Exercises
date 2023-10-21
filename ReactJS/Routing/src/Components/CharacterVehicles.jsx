import { useParams, Link } from "react-router-dom";
import { useState, useEffect } from "react";

const baseUrl = "https://swapi.dev/api/starships";

//Imagine we make a call to an API and retrieve all vehicles the character has ever driven
export default function CharacterVehicles() {
    const { characterId } = useParams();
    const [vehicles, setVehicles] = useState([]);

    useEffect(() => {
        fetch(baseUrl)
            .then((response) => response.json())
            .then((data) => setVehicles(data.results));
    }, [characterId]);

    return (
        <>
            {vehicles.map((x) => (
                <div key={x.url}>
                    <Link
                        to={`/vehicles/${x.url
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
