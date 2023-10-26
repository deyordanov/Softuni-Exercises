import PropTypes from "prop-types";
import { Link } from "react-router-dom";

export default function CatalogueItem({ _id, imageUrl, title }) {
    return (
        <div className="allGames bg-slate-800">
            <div className="allGames-info flex flex-col items-start content-center">
                <img src={imageUrl} className="shadow-2xl shadow-black" />

                <h2 className="text-white text-2xl font-bold ">{title}</h2>
                <Link
                    to={_id}
                    className="px-3 btn submit bg-slate-700 hover:shadow-lg hover:shadow-white"
                >
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
