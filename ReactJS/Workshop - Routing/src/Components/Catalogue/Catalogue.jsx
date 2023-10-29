import CatalogueItem from "./CatalogueItem/CatalogueItem";
import { useContext } from "react";

import { CatalogueContext } from "../../Contexts/CatalogueContext";

export default function Catalogue() {
    const { games } = useContext(CatalogueContext);

    return (
        <section id="catalog-page">
            <h1>All Games</h1>
            {Object.values(games)?.map((x) => (
                <CatalogueItem key={x._id} {...x} />
            ))}

            {games.length === 0 && (
                <h3 className="no-articles">No articles yet</h3>
            )}
        </section>
    );
}
