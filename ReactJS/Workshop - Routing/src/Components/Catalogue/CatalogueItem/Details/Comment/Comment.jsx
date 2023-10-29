import PropTypes from "prop-types";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faHeart } from "@fortawesome/free-solid-svg-icons";
import { useState, useEffect } from "react";

export default function Comment({ comment, onCommentLike, userId }) {
    const [liked, setLiked] = useState(false);

    useEffect(() => {
        setLiked(comment.likedBy.includes(userId));
    }, [comment.likedBy, userId]);

    return (
        <li className="comment bg-slate-500 flex items-center justify-center flex-col max-w-[300px] overflow-hidden break-words px-8 relative py-6">
            <p className="rounded-xl text-2xl text-center mb-3">
                <b>{comment.author}</b>: {comment.comment}
            </p>

            <div className="flex absolute bottom-0 right-0 gap-2.5 items-center">
                <p className="text-2xl p-0">{comment.likedBy.length}</p>
                <FontAwesomeIcon
                    onClick={() => onCommentLike(comment, setLiked)}
                    className={`${
                        liked ? "text-red-500" : "text-slate-100"
                    } text-4xl cursor-pointer`}
                    icon={faHeart}
                />
            </div>
        </li>
    );
}

Comment.propTypes = {
    comment: PropTypes.object,
    onCommentLike: PropTypes.func,
    userId: PropTypes.string,
};
