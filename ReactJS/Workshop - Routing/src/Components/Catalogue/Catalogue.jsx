import CatalogueItem from "./CatalogueItem/CatalogueItem";

import { useGameContext } from "../../Contexts/GameContext";

export default function Catalogue() {
    let { games } = useGameContext();

    games = games ?? [];

    return (
        <section id="catalog-page">
            <h1>All Games</h1>
            {Object.values(games).map((x) => (
                <CatalogueItem key={x._id} {...x} />
            ))}

            {games?.length === 0 && (
                <h3 className="no-articles">No articles yet</h3>
            )}
        </section>
    );
}
