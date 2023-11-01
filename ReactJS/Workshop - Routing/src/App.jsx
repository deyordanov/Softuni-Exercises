import { Routes, Route } from "react-router-dom";
import { useState, useEffect } from "react";

import { AuthProvider } from "./Contexts/AuthContext";
import { CatalogueContext } from "./Contexts/CatalogueContext";
import { DetailsContext } from "./Contexts/DetailsContext";

import {
    useAllGamesQuery,
    useCreateGameMutation,
    useDeleteGameMutation,
    useEditGameMutation,
} from "./queries/appQueries";

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
import IsLoading from "./utilities/IsLoading";

import "bootstrap/dist/css/bootstrap.min.css";
import "../public/styles/style.css";

function App() {
    const [games, setGames] = useState([]);
    const allGamesData = useAllGamesQuery();
    const createGameMutation = useCreateGameMutation();
    const deleteGameMutation = useDeleteGameMutation();
    const editGameMutation = useEditGameMutation();

    useEffect(() => {
        setGames(allGamesData?.data);
    }, [allGamesData?.data]);

    //Leaving these create/delete/edit functions for an easier understanding of what each one does
    //Otherwise the wrappers can be used instead
    const onCreateSubmit = (data) => {
        createGameMutation.mutate(data);
    };

    const onGameDelete = (gameId) => {
        deleteGameMutation.mutate(gameId);
    };

    const onEditSubmit = (data) => {
        editGameMutation.mutate(data);
    };

    const catalogueContextData = {
        games: games ?? [],
    };

    const detailsContextData = {
        onGameDelete,
    };

    if (
        allGamesData.isPending ||
        createGameMutation.isPending ||
        deleteGameMutation.isPending ||
        editGameMutation.isPending
    )
        return <IsLoading />;

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
                        element={
                            <Create
                                // onCreateSubmit={createGameMutation.mutate}
                                onCreateSubmit={onCreateSubmit}
                            />
                        }
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
