import PropTypes from "prop-types";
import { Outlet, useParams } from "react-router-dom";
import { useOneGameQuery } from "../../queries/detailsQueries";
import IsLoading from "../IsLoading/IsLoading";
import GameNotFound from "./GameNotFound";

export default function GameGuard({ children }) {
    const { gameId } = useParams();

    console.log(gameId);

    const { data, isLoading, isError, error } = useOneGameQuery(gameId);

    //If the data has not been fetched yet we will display a spinner
    if (isLoading) {
        return <IsLoading />;
    }

    //If an error occurs we will display it in a simple manner
    if (isError) {
        console.error(error);
        return <div>Error fetching game details</div>;
    }

    // At this point, the data has been successfully fetched and is available in the `data` object
    const game = data;

    console.log(game);

    if (!game) {
        return <GameNotFound />;
    }

    return children ?? <Outlet />;
}

GameGuard.propTypes = {
    children: PropTypes.node,
};
