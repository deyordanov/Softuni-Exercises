import { Routes, Route } from "react-router-dom";
import { useState, useEffect } from "react";

import Header from "./Components/Header/Header";
import Main from "./Components/Main/Main";
import Home from "./Components/Home/Home";
import Login from "./Components/Login/Login";
import Register from "./Components/Register/Register";
import Create from "./Components/Create/Create";
import Edit from "./Components/Edit/Edit";
import Details from "./Components/Details/Details";
import Catalogue from "./Components/Catalogue/Catalogue";

import * as gameService from "./Services/gameService";

function App() {
    const [games, setGames] = useState([]);

    useEffect(() => {
        gameService
            .getAll()
            .then((data) => {
                console.log(data);
                setGames(data);
            })
            .catch((error) => console.log(error));
    }, []);

    return (
        <>
            <div id="box">
                <Header />
                <Main />

                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/login" element={<Login />}></Route>
                    <Route path="/register" element={<Register />}></Route>
                    <Route path="/create" element={<Create />}></Route>
                    <Route path="/catalogue" element={<Catalogue />}></Route>
                </Routes>
            </div>
        </>
    );
}

export default App;
