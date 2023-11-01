import { useContext } from "react";
import { Navigate, Outlet } from "react-router-dom";
import PropTypes from "prop-types";

import { AuthContext } from "../../Contexts/AuthContext";

export default function RouteGuard({ children }) {
    const { isAuthenticated } = useContext(AuthContext);

    if (!isAuthenticated) return <Navigate to={"/login"} />;

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
