import { useState, useEffect } from "react";
import { useParams, useNavigate, Link, Routes, Route } from "react-router-dom";

import CharacterMovies from "./CharacterMovies";
import CharacterVehicles from "./CharacterVehicles";
import CharacterStarships from "./CharacterStarships";
import Navigation from "./Navigation";

const baseUrl = "https://swapi.dev/api/people";

export default function Character() {
    const { characterId } = useParams();
    const navigate = useNavigate();
    const [character, setCharacter] = useState({});

    const onReturnClick = () => {
        //navigate(-1) -> return to the page you previously visited
        navigate("/characters");
    };

    useEffect(() => {
        fetch(`${baseUrl}/${characterId}`)
            .then((res) => res.json())
            .then((data) => {
                setCharacter(data);
            });
    }, [characterId]);

    return (
        <>
            <h2>{character.name}</h2>
            <button onClick={onReturnClick}>Return</button>

            <Navigation>
                <li>
                    <Link to={"movies"}>Movies</Link>
                </li>
                <li>
                    <Link to={"vehicles"}>Vehicles</Link>
                </li>
                <li>
                    <Link to={"starships"}>Starships</Link>
                </li>
            </Navigation>

            <Routes>
                <Route path={"/movies"} element={<CharacterMovies />}></Route>
                <Route
                    path={"/vehicles"}
                    element={<CharacterVehicles />}
                ></Route>
                <Route
                    path={"/starships"}
                    element={<CharacterStarships />}
                ></Route>
            </Routes>
        </>
    );
}
