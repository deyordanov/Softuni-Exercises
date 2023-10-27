import PropTypes from "prop-types";

export default function Comment({ author, comment }) {
    return (
        <li className="comment bg-slate-500 flex items-center justify-center">
            <p className="rounded-xl text-2xl text-center">
                <b>{author}</b>: {comment}
            </p>
        </li>
    );
}

Comment.propTypes = {
    author: PropTypes.string,
    comment: PropTypes.string,
};
