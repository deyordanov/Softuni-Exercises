import PropTypes from "prop-types";

export default function Comment({ author, comment }) {
    return (
        <li className="comment">
            <p>
                {author}: {comment}
            </p>
        </li>
    );
}

Comment.propTypes = {
    author: PropTypes.string,
    comment: PropTypes.string,
};
