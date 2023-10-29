import { Link } from "react-router-dom";
import { useContext } from "react";

import { AuthContext } from "../../Contexts/AuthContext";

export default function Header() {
    const { isAuthenticated } = useContext(AuthContext);

    return (
        <header className="flex justify-between max-w-[1200px] ">
            {/* <!-- Navigation --> */}
            <h1>
                <Link className="home" to="/">
                    <img
                        src="../../../public/images/logo.png"
                        alt="PixelPulse"
                        className="w-[230px]"
                    />
                </Link>
            </h1>
            <nav className="flex items-center m-0 font-mono text-3xl">
                <Link to="/catalogue">All games</Link>
                {/* <!-- Logged-in users --> */}
                {isAuthenticated && (
                    <div id="user">
                        <Link to="/create">Create Game</Link>
                        <Link to="/logout">Logout</Link>
                    </div>
                )}
                {/* <!-- Guest users --> */}
                {!isAuthenticated && (
                    <div id="guest">
                        <Link to="/login">Login</Link>
                        <Link to="/register">Register</Link>
                    </div>
                )}
            </nav>
        </header>
    );
}
