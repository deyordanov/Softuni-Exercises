import { Navigate } from "react-router-dom";
import { useEffect, useContext } from "react";

import { AuthContext } from "../../Contexts/AuthContext";

export default function Logout() {
    const { onLogout } = useContext(AuthContext);

    useEffect(() => {
        onLogout();
    }, [onLogout]);

    return <Navigate to={"/"} />;
}
