import PropTypes from "prop-types";

export default function Comment({ author, comment }) {
    return (
        <li className="comment">
            <p className="bg-slate-500 rounded-xl text-2xl">
                <b>{author}</b>: {comment}
            </p>
        </li>
    );
}

Comment.propTypes = {
    author: PropTypes.string,
    comment: PropTypes.string,
};
