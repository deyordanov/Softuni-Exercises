import { Routes, Route, useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";

import { AuthContext } from "./Contexts/AuthContext";
import Header from "./Components/Header/Header";
import Main from "./Components/Main/Main";
import Home from "./Components/Home/Home";
import Login from "./Components/Login/Login";
import Register from "./Components/Register/Register";
import Create from "./Components/Create/Create";
import Catalogue from "./Components/Catalogue/Catalogue";
import "../public/styles/style.css";

import * as gameService from "./Services/gameService";
import Details from "./Components/Catalogue/CatalogueItem/Details/Details";

function App() {
    const [games, setGames] = useState([]);
    const [auth, setAuth] = useState({});
    const navigate = useNavigate();

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

        navigate("/catalogue");
    };

    const onLoginSubmit = async (data) => {
        console.log(data);
    };

    return (
        <AuthContext.Provider value={{ onLoginSubmit }}>
            <div id="box" className="flex flex-col w-full h-screen">
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
        </AuthContext.Provider>
    );
}

export default App;
