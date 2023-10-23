import PropTypes from "prop-types";
import CatalogueItem from "./CatalogueItem/CatalogueItem";

export default function Catalogue({ games }) {
    return (
        <section id="catalog-page">
            <h1>All Games</h1>
            {Object.values(games).map((x) => (
                <CatalogueItem key={x._id} {...x} />
            ))}

            {games.length === 0 && (
                <h3 className="no-articles">No articles yet</h3>
            )}
        </section>
    );
}

Catalogue.propTypes = {
    games: PropTypes.array,
};
