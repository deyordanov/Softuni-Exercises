import { useState, useEffect, createContext, useContext } from "react";
import PropTypes from "prop-types";

import {
    useAllGamesQuery,
    useCreateGameMutation,
    useDeleteGameMutation,
    useEditGameMutation,
} from "../queries/appQueries";

import IsLoading from "../Components/IsLoading/IsLoading";

const GameContext = createContext();

export const GameProvider = ({ children }) => {
    const [games, setGames] = useState([]);
    const allGamesData = useAllGamesQuery();
    const createGameMutation = useCreateGameMutation();
    const deleteGameMutation = useDeleteGameMutation();
    const editGameMutation = useEditGameMutation();

    useEffect(() => {
        setGames(allGamesData?.data);
    }, [allGamesData?.data]);

    //Leaving these create/delete/edit functions for an easier understanding of what each one does
    //Otherwise the wrappers can be used
    const onCreateSubmit = (data) => {
        createGameMutation.mutate(data);
    };

    const onGameDelete = (gameId) => {
        deleteGameMutation.mutate(gameId);
    };

    const onEditSubmit = (data) => {
        editGameMutation.mutate(data);
    };

    if (
        allGamesData.isPending ||
        createGameMutation.isPending ||
        deleteGameMutation.isPending ||
        editGameMutation.isPending
    )
        return <IsLoading />;

    const gameContextData = {
        games,
        onCreateSubmit,
        onGameDelete,
        onEditSubmit,
    };

    return (
        <GameContext.Provider value={gameContextData}>
            {children}
        </GameContext.Provider>
    );
};

export const useGameContext = () => {
    return useContext(GameContext);
};

GameProvider.propTypes = {
    children: PropTypes.object,
};
