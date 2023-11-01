import { useNavigate } from "react-router-dom";
import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";

import * as gameService from "../Services/gameService";
import { useAppQueryContext } from "../Contexts/AppQueryContext";

export const useAllGamesQuery = () => {
    return useQuery({
        queryKey: ["games"],
        queryFn: gameService.getAll,
    });
};

export const useCreateGameMutation = () => {
    const { navigate, queryClient } = useAppQueryContext();
    return useMutation({
        mutationFn: (data) => gameService.create(data),
        onSuccess: async (data) => {
            // data -> new game
            // Manually set the new games state
            queryClient.setQueryData(["games"], (oldGames) => ({
                ...oldGames,
                data,
            }));

            //Invalidate the data to make sure it is up to date with the server
            queryClient.invalidateQueries(["games"], { exact: true });

            // Then navigate
            navigate("/catalogue");
        },
    });
};
