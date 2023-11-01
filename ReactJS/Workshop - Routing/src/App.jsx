import { Routes, Route, useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";

import { AuthProvider } from "./Contexts/AuthContext";
import { CatalogueContext } from "./Contexts/CatalogueContext";
import { DetailsContext } from "./Contexts/DetailsContext";
import * as gameService from "./Services/gameService";
import { useAllGamesQuery, useCreateGameMutation } from "./queries/appQueries";

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
    const navigate = useNavigate();

    const queryClient = useQueryClient();

    // const allGamesQuery = useQuery({
    //     queryKey: ["games"],
    //     queryFn: gameService.getAll,
    // });

    const allGamesData = useAllGamesQuery();

    useEffect(() => {
        setGames(allGamesData?.data);
    }, [allGamesData?.data]);

    const createGameMutation = useCreateGameMutation();

    const onCreateSubmit = async (data) => {
        createGameMutation.mutate(data);
    };

    const deleteGameMutation = useMutation({
        mutationFn: (gameId) => gameService.remove(gameId),
        onSuccess: async (data) => {
            // data -> deleted game id

            // queryClient.invalidateQueries(["games"]);

            // await queryClient.refetchQueries(["games"]);
            // Manually set the new games state
            queryClient.setQueryData(["games"], (oldGames) =>
                oldGames.filter((game) => game._id !== data)
            );

            //Invalidate the data to make sure it is up to date with the server
            queryClient.invalidateQueries(["games"], { exact: true });

            // Then navigate
            navigate("/catalogue");
        },
    });

    const onGameDelete = async (gameId) => {
        deleteGameMutation.mutate(gameId);
    };

    const editGameMutation = useMutation({
        mutationFn: ({ data }) => gameService.edit(data),
        onSuccess: async (data) => {
            // Manually set the new games state
            queryClient.setQueryData(["games"], (oldGames) => {
                return oldGames.map((game) =>
                    game._id === data._id ? data : game
                );
            });

            //Invalidate the data to make sure it is up to date with the server
            queryClient.invalidateQueries(["games"], { exact: true });

            // Then navigate
            navigate(`/catalogue/${data._id}`);
        },
    });

    const onEditSubmit = async (data) => {
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
        deleteGameMutation.isIdle
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
