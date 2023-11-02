import { useQuery, useMutation } from "@tanstack/react-query";

import * as commentService from "../Services/commentService";
import * as gameService from "../Services/gameService";
import { useQueryContext } from "../Contexts/QueryContext";

export const useOneGameQuery = (gameId) => {
    return useQuery({
        queryKey: ["game", gameId],
        queryFn: () => gameService.getOne(gameId),
    });
};

export const useGetGameComments = (gameId) => {
    return useQuery({
        queryKey: ["comments", gameId],
        queryFn: () => commentService.getGameComments(gameId),
    });
};

export const useCreateCommentMutation = () => {
    const { queryClient } = useQueryContext();

    return useMutation({
        //mutationFn accepts a single parameter!
        mutationFn: ({ data, gameId, userId }) => {
            return commentService.create({
                ...data,
                gameId,
                likedBy: [],
                userId,
            });
        },
        onSuccess: async () => {
            queryClient.invalidateQueries(["comments"]);

            await queryClient.refetchQueries(["comments"]);
        },
    });
};

export const useCommentLikeMutation = () => {
    const { queryClient } = useQueryContext();
    return useMutation({
        mutationFn: ({ comment, action, userId }) =>
            commentService.like(comment, action, userId),
        onSuccess: async () => {
            queryClient.invalidateQueries(["comments"]);

            await queryClient.refetchQueries(["comments"]);
        },
    });
};
