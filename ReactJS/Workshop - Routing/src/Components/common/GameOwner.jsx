import PropTypes from "prop-types";
import { Outlet, useParams, Navigate } from "react-router-dom";

import { useOneGameQuery } from "../../queries/detailsQueries";
import { useDetailsContext } from "../../Contexts/DetailsContext";
import IsLoading from "../IsLoading/IsLoading";

export default function GameOwner({ children }) {
    const { gameId } = useParams();
    const { userId } = useDetailsContext();

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

    if (game?._ownerId !== userId) {
        return <Navigate to={`/catalogue/${gameId}`} replace />;
    }

    return children ?? <Outlet />;
}

GameOwner.propTypes = {
    children: PropTypes.node,
};
