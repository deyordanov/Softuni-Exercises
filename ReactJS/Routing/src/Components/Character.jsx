import { useState, useEffect } from "react";
import { useParams, useNavigate, Link, Routes, Route } from "react-router-dom";

import style from "./Navigation.module.css";
import CharacterMovies from "./CharacterMovies";
import CharacterVehicles from "./CharacterVehicles";
import CharacterStarships from "./CharacterStarships";

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

            <nav>
                <ul className={style.navigation}>
                    <li>
                        <Link to={"movies"}>Movies</Link>
                    </li>
                    <li>
                        <Link to={"vehicles"}>Vehicles</Link>
                    </li>
                    <li>
                        <Link to={"starships"}>Starships</Link>
                    </li>
                </ul>
            </nav>

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
