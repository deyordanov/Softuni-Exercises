import { useParams } from "react-router-dom";
import { useEffect, useContext, useReducer } from "react";
import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";

import {
    useOneGameQuery,
    useGetGameComments,
    useCreateCommentMutation,
    useCommentLikeMutation,
} from "../../../../queries/detailsQueries";

import { AuthContext } from "../../../../Contexts/AuthContext";
import { DetailsContext } from "../../../../Contexts/DetailsContext";
import { createReducer } from "../../../../reducers/createReducer";

import Comment from "./Comment/Comment";
import ErrorPage from "../../../ErrorPage/ErrorPage";
import {
    CreateCommentFormKeys,
    DetailsActions,
    LikeCommentActions,
    defaultDetailsUseFormValues,
    initialDetailsReducerValues,
} from "../../../../utilities/constans";

export default function Details() {
    const [state, dispatch] = useReducer(
        createReducer,
        initialDetailsReducerValues
    );
    const { onGameDelete } = useContext(DetailsContext); //
    const { userId } = useContext(AuthContext);
    const { register, handleSubmit, reset } = useForm({
        defaultValues: defaultDetailsUseFormValues,
    });

    const { gameId } = useParams();

    const signleGameData = useOneGameQuery(gameId);
    const gameCommentsData = useGetGameComments();
    const createCommentMutation = useCreateCommentMutation();
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
        createCommentMutation.mutate({ data, gameId, userId });

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

    const isOwner = userId && state.game && userId === state.game._ownerId;
    const isNotOwner = userId && state.game && userId !== state.game._ownerId;

    return (
        <section id="game-details">
            <h1 className="font-mono">Game Details</h1>
            <div className="info-section  bg-slate-800 shadow-2xl shadow-black">
                <div className="game-header">
                    <img className="game-img" src={state.game.imageUrl} />
                    <h1>{state.game.title}</h1>
                    <span className="levels bg-rose-500 text-black border-none text-lg rounded-lg">
                        MaxLevel: {state.game.maxLevel}
                    </span>
                    <p className="type bg-green-500 p-2 rounded-lg border:none text-black text-lg">
                        {state.game.genres}
                    </p>
                </div>

                <p className="text  w-[95%] text-zinc-300 m-auto overflow-hidden break-all">
                    {state.game.description}
                </p>

                <div className="details-comments w-full">
                    {state.comments.length !== 0 && (
                        <>
                            <h2 className="text-3xl text-zinc-300 ml-10">
                                Comments:
                            </h2>
                            <div className="grid grid-cols-2 mb-8">
                                {state.comments.map((x) => (
                                    <Comment
                                        key={x._id}
                                        userId={userId}
                                        comment={x}
                                        onCommentLike={onCommentLike}
                                    />
                                ))}
                            </div>
                        </>
                    )}

                    {state.comments?.length === 0 && (
                        <p className="no-comment text-3xl text-zinc-300 p-4  ml-10 mb-5">
                            No comments.
                        </p>
                    )}
                </div>

                {/* <!-- Edit/Delete buttons ( Only for creator of this game )  --> */}
                {isOwner && (
                    <div className="buttons">
                        <Link
                            to={"edit"}
                            className="button rounded-xl bg-slate-500 hover:bg-blue-500"
                        >
                            Edit
                        </Link>
                        <Link
                            onClick={() => onGameDelete(gameId)}
                            className="button rounded-xl bg-slate-500 hover:bg-red-500"
                            to={"/catalogue"}
                        >
                            Delete
                        </Link>
                    </div>
                )}
            </div>

            {/* <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) --> */}
            {isNotOwner && (
                <article className="create-comment  bg-slate-800 shadow-2xl shadow-black flex flex-col gap-2">
                    <label className="font-mono">Add new comment:</label>
                    <form
                        className="form"
                        onSubmit={handleSubmit(onCommentSubmit)}
                    >
                        <input
                            {...register(CreateCommentFormKeys.AUTHOR)}
                            type="text"
                            name="author"
                            id="author"
                            placeholder="Username...."
                        ></input>
                        <textarea
                            {...register(CreateCommentFormKeys.COMMENT)}
                            className="text-2xl"
                            name="comment"
                            placeholder="Comment......"
                        ></textarea>
                        <input
                            className="btn submit bg-slate-700 w-[40%] hover:shadow-lg hover:shadow-white"
                            type="submit"
                            value="Comment"
                        />
                    </form>
                </article>
            )}
        </section>
    );
}
