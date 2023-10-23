import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";

import * as gameService from "../../../../Services/gameService";
import * as commentService from "../../../../Services/commentService";
import Comment from "./Comment/Comment";

export default function Details() {
    const [data, setData] = useState({
        author: "",
        comment: "",
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

    const onCommentSubmit = (e) => {
        e.preventDefault();
        commentService
            .create({ ...data, gameId })
            .then((data) => setComments([...comments, data]))
            .catch((error) => console.log(error));
        setData({
            author: "",
            comment: "",
        });
    };

    const onChangeHandler = (e) => {
        setData((state) => ({ ...state, [e.target.name]: e.target.value }));
    };

    return (
        <section id="game-details">
            <h1>Game Details</h1>
            <div className="info-section">
                <div className="game-header">
                    <img className="game-img" src={game.imageUrl} />
                    <h1>{game.title}</h1>
                    <span className="levels">MaxLevel: {game.maxLevel}</span>
                    <p className="type">{game.genres}</p>
                </div>

                <p className="text">{game.description}</p>

                {/* <!-- Bonus ( for Guests and Users ) --> */}
                <div className="details-comments">
                    <h2>Comments:</h2>
                    <ul>
                        {/* <!-- list all comments for current game (If any) --> */}
                        {comments.map((x) => (
                            <Comment key={x._id} {...x} />
                        ))}
                    </ul>

                    {comments.length === 0 && (
                        <p className="no-comment">No comments.</p>
                    )}
                </div>

                {/* <!-- Edit/Delete buttons ( Only for creator of this game )  --> */}
                <div className="buttons">
                    <a href="#" className="button">
                        Edit
                    </a>
                    <a href="#" className="button">
                        Delete
                    </a>
                </div>
            </div>

            {/* <!-- Bonus --> */}
            {/* <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) --> */}
            <article className="create-comment">
                <label>Add new comment:</label>
                <form className="form" onSubmit={onCommentSubmit}>
                    <input
                        value={data.author}
                        onChange={onChangeHandler}
                        type="text"
                        name="author"
                        id="author"
                        placeholder="Username...."
                    />
                    <textarea
                        value={data.comment}
                        onChange={onChangeHandler}
                        name="comment"
                        placeholder="Comment......"
                    ></textarea>
                    <input
                        className="btn submit"
                        type="submit"
                        value="Add Comment"
                    />
                </form>
            </article>
        </section>
    );
}
