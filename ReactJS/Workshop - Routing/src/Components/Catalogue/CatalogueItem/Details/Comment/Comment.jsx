import PropTypes from "prop-types";

export default function Comment({ author, comment }) {
    return (
        <li className="comment bg-slate-500">
            <p className="rounded-xl text-2xl">
                <b>{author}</b>: {comment}
            </p>
        </li>
    );
}

Comment.propTypes = {
    author: PropTypes.string,
    comment: PropTypes.string,
};
