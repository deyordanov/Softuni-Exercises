import { Routes, Route } from "react-router-dom";
import { useState, useEffect } from "react";

import Header from "./Components/Header/Header";
import Main from "./Components/Main/Main";
import Home from "./Components/Home/Home";
import Login from "./Components/Login/Login";
import Register from "./Components/Register/Register";
import Create from "./Components/Create/Create";
import Catalogue from "./Components/Catalogue/Catalogue";

import * as gameService from "./Services/gameService";
import Details from "./Components/Catalogue/CatalogueItem/Details/Details";

function App() {
    const [games, setGames] = useState([]);

    useEffect(() => {
        gameService
            .getAll()
            .then((data) => {
                setGames(data);
            })
            .catch((error) => console.log(error));
    }, []);

    const onCreateSubmit = async (data) => {
        const newGame = await gameService.create(data);

        setGames((state) => [...state, newGame]);
    };

    return (
        <>
            <div id="box">
                <Header />
                <Main />

                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/login" element={<Login />}></Route>
                    <Route path="/register" element={<Register />}></Route>
                    <Route
                        path="/create"
                        element={<Create onCreateSubmit={onCreateSubmit} />}
                    ></Route>
                    <Route
                        path="/catalogue"
                        element={<Catalogue games={games} />}
                    ></Route>
                    <Route
                        path="/catalogue/:gameId"
                        element={<Details />}
                    ></Route>
                </Routes>
            </div>
        </>
    );
}

export default App;
