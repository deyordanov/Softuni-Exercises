import { Routes, Route, useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";

import { AuthProvider } from "./Contexts/AuthContext";
import { CatalogueContext } from "./Contexts/CatalogueContext";
import { DetailsContext } from "./Contexts/DetailsContext";
import * as gameService from "./Services/gameService";

// import { withAuth } from "./hoc/withAuth";
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

    const onEditSubmit = async (data, gameId) => {
        const game = await gameService.edit(data, gameId);
        setGames((state) => state.map((x) => (x._id === game._id ? game : x)));
        navigate(`/catalogue/${gameId}`);
    };

    const onGameDelete = async (gameId) => {
        const deletedGameId = await gameService.remove(gameId);

        setGames((state) => state.filter((x) => x._id !== deletedGameId));
    };

    const catalogueContextData = {
        games,
    };

    const detailsContextData = {
        onGameDelete,
    };

    // const HOC = withAuth(Login);

    return (
        <AuthProvider>
            <div
                id="box"
                className="flex flex-col w-full overflow-y-auto h-screen box-border"
            >
                <Header />
                <Main />

                {/* Adding more contexts than necessary purely for practice! */}
                <Routes>
                    <Route path="/" element={<Home />} />
                    {/* <Route path="/login" element={<HOC props={props} />}></Route> */}
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
        </AuthProvider>
    );
}

export default App;
