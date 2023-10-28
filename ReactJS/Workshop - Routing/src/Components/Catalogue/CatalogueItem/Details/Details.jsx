import { useParams } from "react-router-dom";
import { useState, useEffect, useContext } from "react";
import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";

import * as gameService from "../../../../Services/gameService";
import * as commentService from "../../../../Services/commentService";
import { AuthContext } from "../../../../Contexts/AuthContext";
import { DetailsContext } from "../../../../Contexts/DetailsContext";
import Comment from "./Comment/Comment";
import { CreateCommentFormKeys } from "../../../../utilities/constans";

export default function Details() {
    const { onGameDelete } = useContext(DetailsContext);
    const { userId } = useContext(AuthContext);
    const {
        register,
        handleSubmit,
        formState: { errors },
        reset,
    } = useForm({
        defaultValues: {
            [CreateCommentFormKeys.AUTHOR]: "",
            [CreateCommentFormKeys.COMMENT]: "",
        },
    });

    const [comments, setComments] = useState([]);
    const { gameId } = useParams();
    const [game, setGame] = useState({});

    useEffect(() => {
        gameService.getOne(gameId).then((response) => setGame(response));
    }, [gameId]);

    useEffect(() => {
        commentService
            .getGameComments(gameId)
            .then((data) => {
                setComments(data);
            })
            .catch((error) => console.log(error));
    }, [gameId]);

    const onCommentSubmit = (data) => {
        commentService
            .create({ ...data, gameId, likes: 0, likedBy: [] })
            .then((newComment) => {
                setComments([...comments, newComment]);
                reset({
                    // Reset the form fields
                    [CreateCommentFormKeys.AUTHOR]: "",
                    [CreateCommentFormKeys.COMMENT]: "",
                });
            })
            .catch((error) => console.log(error));
    };

    const onCommentLike = (comment, setLiked) => {
        const isOwner = comment._ownerId === userId;

        if (!isOwner) {
            setLiked((state) => {
                if (!state) {
                    commentService
                        .like(comment, "add", userId)
                        .then((newComment) =>
                            setComments((state) =>
                                state.map((x) =>
                                    x._id === newComment._id ? newComment : x
                                )
                            )
                        );
                } else {
                    commentService
                        .like(comment, "remove", userId)
                        .then((newComment) =>
                            setComments((state) =>
                                state.map((x) =>
                                    x._id === newComment._id ? newComment : x
                                )
                            )
                        );
                }

                return !state;
            });
        }
    };

    const isOwner = userId && userId === game._ownerId;
    const isNotOwner = userId && userId !== game._ownerId;

    return (
        <section id="game-details">
            <h1 className="font-mono">Game Details</h1>
            <div className="info-section  bg-slate-800 shadow-2xl shadow-black">
                <div className="game-header">
                    <img className="game-img" src={game.imageUrl} />
                    <h1>{game.title}</h1>
                    <span className="levels bg-rose-500 text-black border-none text-lg rounded-lg">
                        MaxLevel: {game.maxLevel}
                    </span>
                    <p className="type bg-green-500 p-2 rounded-lg border:none text-black text-lg">
                        {game.genres}
                    </p>
                </div>

                <p className="text  w-[95%] text-zinc-300 m-auto">
                    {game.description}
                </p>

                <div className="details-comments w-full">
                    {comments.length !== 0 && (
                        <>
                            <h2 className="text-3xl text-zinc-300 ml-10">
                                Comments:
                            </h2>
                            <div className="grid grid-cols-2 mb-8">
                                {comments.map((x) => (
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

                    {comments.length === 0 && (
                        <p className="no-comment text-3xl text-zinc-300 p-4 shadow-2xl ml-10 mb-5">
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
                            {...register(CreateCommentFormKeys.AUTHOR, {
                                required: "This field is required!",
                            })}
                            type="text"
                            name="author"
                            id="author"
                            placeholder="Username...."
                        ></input>
                        <textarea
                            {...register(CreateCommentFormKeys.COMMENT, {
                                required: "This field is required!",
                            })}
                            className="text-2xl"
                            name="comment"
                            placeholder="Comment......"
                        ></textarea>
                        <input
                            className="btn submit bg-slate-700 w-[40%] hover:shadow-lg hover:shadow-white"
                            type="submit"
                            value="Edit"
                        />
                    </form>
                </article>
            )}
        </section>
    );
}
