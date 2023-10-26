import { Routes, Route, useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";

import { AuthContext } from "./Contexts/AuthContext";
import { CatalogueContext } from "./Contexts/CatalogueContext";
import { DetailsContext } from "./Contexts/DetailsContext";
import * as gameService from "./Services/gameService";
import * as authService from "./Services/authService";

import Header from "./Components/Header/Header";
import Main from "./Components/Main/Main";
import Home from "./Components/Home/Home";
import Login from "./Components/Login/Login";
import Register from "./Components/Register/Register";
import Create from "./Components/Create/Create";
import Catalogue from "./Components/Catalogue/Catalogue";
import Details from "./Components/Catalogue/CatalogueItem/Details/Details";
import Edit from "./Components/Edit/Edit";
import Logout from "./Components/Logout/Logout";

import "bootstrap/dist/css/bootstrap.min.css";
import "../public/styles/style.css";

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
        const newGame = await gameService.create(
            { ...data, email: auth.email },
            auth.accessToken
        );

        setGames((state) => [...state, newGame]);

        navigate("/catalogue");
    };

    const onLoginSubmit = async (data) => {
        try {
            const response = await authService.login(data);

            setAuth(response);

            navigate("/catalogue");
        } catch (error) {
            console.log("Invalid email or password!");
        }
    };

    const onRegisterSubmit = async (data) => {
        try {
            const response = await authService.register(data);

            setAuth(response);

            navigate("/catalogue");
        } catch (error) {
            console.log("Couldn`t register!");
        }
    };

    const onEditSubmit = async (data, gameId) => {
        //First we delete the given game from the server and filter it our from the games state
        const deletedGameId = await gameService.remove(
            gameId,
            auth.accessToken
        );
        setGames((state) => state.filter((x) => x._id !== deletedGameId));

        //Then we add the game back to the server and the games state with its updated data
        const newGame = await gameService.create(data, auth.accessToken);
        setGames((state) => [...state, newGame]);

        navigate(`/catalogue/${newGame._id}`);
    };

    //The patch request dosen`t seem to be working properly - CORS
    // const onEditSubmit = async (data, gameId) => {
    //     const response = await gameService.edit(data, gameId, auth.accessToken);
    //     console.log(response);
    //     navigate(`/catalogue/${gameId}`);
    // };

    const onLogout = async () => {
        // await authService.logout();

        setAuth({});
    };

    const onGameDelete = async (gameId) => {
        const deletedGameId = await gameService.remove(
            gameId,
            auth.accessToken
        );

        setGames((state) => state.filter((x) => x._id !== deletedGameId));
    };

    const authContextData = {
        onLoginSubmit,
        onRegisterSubmit,
        onLogout,
        userId: auth._id,
        userEmail: auth.email,
        token: auth.accessToken,
        isAuthenticated: !!auth.accessToken,
    };

    const catalogueContextData = {
        games,
    };

    const detailsContextData = {
        onGameDelete,
    };

    return (
        <AuthContext.Provider value={authContextData}>
            <div
                id="box"
                className="flex flex-col w-full overflow-y-auto h-screen box-border"
            >
                <Header />
                <Main />

                {/* Adding more contexts than necessary purely for practice! */}
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/login" element={<Login />}></Route>
                    <Route path="/logout" element={<Logout />}></Route>
                    <Route path="/register" element={<Register />}></Route>
                    <Route
                        path="/create"
                        element={<Create onCreateSubmit={onCreateSubmit} />}
                    ></Route>
                    <Route
                        path="/catalogue"
                        element={
                            <CatalogueContext.Provider
                                value={catalogueContextData}
                            >
                                <Catalogue />
                            </CatalogueContext.Provider>
                        }
                    ></Route>
                    <Route
                        path="/catalogue/:gameId"
                        element={
                            <DetailsContext.Provider value={detailsContextData}>
                                <Details />
                            </DetailsContext.Provider>
                        }
                    ></Route>
                    <Route
                        path="/catalogue/:gameId/edit"
                        element={<Edit onEditSubmit={onEditSubmit} />}
                    ></Route>
                </Routes>
            </div>
        </AuthContext.Provider>
    );
}

export default App;
