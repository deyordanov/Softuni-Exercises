import { useQuery, useMutation } from "@tanstack/react-query";

import * as gameService from "../Services/gameService";
import { useQueryContext } from "../Contexts/QueryContext";

export const useAllGamesQuery = () => {
    return useQuery({
        queryKey: ["games"],
        queryFn: gameService.getAll,
    });
};

export const useCreateGameMutation = () => {
    const { navigate, queryClient } = useQueryContext();

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

export const useDeleteGameMutation = () => {
    const { navigate, queryClient } = useQueryContext();

    return useMutation({
        mutationFn: (gameId) => gameService.remove(gameId),
        onSuccess: async () => {
            //Invalidate and refetch
            queryClient.invalidateQueries(["games"], { exact: true });

            await queryClient.refetchQueries(["games"]);

            // Then navigate
            navigate("/catalogue");
        },
    });
};

export const useEditGameMutation = () => {
    const { navigate, queryClient } = useQueryContext();

    return useMutation({
        mutationFn: (data) => gameService.edit(data),
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
};
