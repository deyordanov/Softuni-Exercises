import PropTypes from "prop-types";
import { Link } from "react-router-dom";

export default function CatalogueItem({ _id, imageUrl, genres, title }) {
    return (
        <div className="allGames">
            <div className="allGames-info">
                <img src={imageUrl} />
                <h6>{genres}</h6>
                <h2>{title}</h2>
                <Link to={_id} className="details-button">
                    Details
                </Link>
            </div>
        </div>
    );
}

CatalogueItem.propTypes = {
    imageUrl: PropTypes.string,
    genres: PropTypes.string,
    title: PropTypes.string,
    _id: PropTypes.string,
};
