import { useEffect, useReducer, createContext, useContext } from "react";
import { useParams } from "react-router-dom";
import { useForm } from "react-hook-form";
import PropTypes from "prop-types";

import {
    useOneGameQuery,
    useGetGameComments,
    useCreateCommentMutation,
    useCommentLikeMutation,
} from "../queries/detailsQueries";

import { AuthContext } from "../Contexts/AuthContext";
import { createReducer } from "../reducers/createReducer";

import ErrorPage from "../Components/ErrorPage/ErrorPage";
import {
    CreateCommentFormKeys,
    DetailsActions,
    LikeCommentActions,
    defaultDetailsUseFormValues,
    initialDetailsReducerValues,
} from "../utilities/constans";

const DetailsContext = createContext();

export const DetailsProvider = ({ children }) => {
    const [state, dispatch] = useReducer(
        createReducer,
        initialDetailsReducerValues
    );
    const { register, handleSubmit, reset } = useForm({
        defaultValues: defaultDetailsUseFormValues,
    });
    const { gameId } = useParams();
    const { userId } = useContext(AuthContext);

    const signleGameData = useOneGameQuery(gameId);
    const gameCommentsData = useGetGameComments(gameId);
    const createCommentMutation = useCreateCommentMutation(gameId);
    const commentLikeMutation = useCommentLikeMutation();

    useEffect(() => {
        dispatch({
            type: DetailsActions.SET_GAME,
            payload: { game: signleGameData?.data ?? {} },
        });
    }, [signleGameData?.data]);

    useEffect(() => {
        dispatch({
            type: DetailsActions.SET_COMMENTS,
            payload: { comments: gameCommentsData?.data ?? [] },
        });
    }, [gameCommentsData?.data]);

    const onCommentSubmit = (data) => {
        createCommentMutation.mutate({ data, userId });

        reset({
            // Reset the form fields
            [CreateCommentFormKeys.AUTHOR]: "",
            [CreateCommentFormKeys.COMMENT]: "",
        });
    };

    const onCommentLike = (comment, setLiked) => {
        const isOwner = comment.userId === userId;

        if (!isOwner) {
            setLiked((currentLikeState) => {
                commentLikeMutation.mutate({
                    comment,
                    action: !currentLikeState
                        ? LikeCommentActions.ADD
                        : LikeCommentActions.REMOVE,
                    userId,
                });

                return !currentLikeState;
            });
        }
    };

    if (
        signleGameData.isError ||
        gameCommentsData.isError ||
        createCommentMutation.isError ||
        commentLikeMutation.isError
    )
        return <ErrorPage />;

    const detailsContextData = {
        onCommentSubmit,
        onCommentLike,
        register,
        handleSubmit,
        state,
        userId,
        gameId,
    };

    return (
        <DetailsContext.Provider value={detailsContextData}>
            {children}
        </DetailsContext.Provider>
    );
};

export const useDetailsContext = () => {
    return useContext(DetailsContext);
};

DetailsProvider.propTypes = {
    children: PropTypes.object,
};
