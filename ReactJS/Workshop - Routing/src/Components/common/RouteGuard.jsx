import { useContext } from "react";
import { Navigate, Outlet } from "react-router-dom";
import PropTypes from "prop-types";

import { AuthContext } from "../../Contexts/AuthContext";
import usePreviousLocation from "../../hooks/usePreviousLocation";

export default function RouteGuard({ children }) {
    const previousLocation = usePreviousLocation();

    const { isAuthenticated } = useContext(AuthContext);

    if (!isAuthenticated)
        return (
            <Navigate
                to={{
                    pathname: "/login",
                    state: { from: previousLocation },
                }}
            />
        );

    return children ?? <Outlet />;
}

// export default function RouteGuard({ children }) {
//     const { isAuthenticated } = useContext(AuthContext);

//     if (!isAuthenticated) return <Navigate to={"/login"} />;

//     return <>{children}</>;
// }

RouteGuard.propTypes = {
    children: PropTypes.object,
};
