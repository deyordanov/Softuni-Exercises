import PropTypes from "prop-types";
import { Link } from "react-router-dom";

export default function CharacterListItem({ name, gender, url }) {
    const id = url
        .split("/")
        .filter((x) => x)
        .pop();

    return (
        <div>
            <Link
                style={{ color: gender === "male" ? "blue" : "pink" }}
                to={`/characters/${id}`}
            >
                {name}
            </Link>
        </div>
    );
}

CharacterListItem.propTypes = {
    name: PropTypes.string,
    gender: PropTypes.string,
    url: PropTypes.string,
};
