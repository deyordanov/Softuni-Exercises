import { Link } from "react-router-dom";

export default function Header() {
    return (
        <header className="flex flex-row justify-between mb-24">
            {/* <!-- Navigation --> */}
            <h1>
                <Link className="home text-5xl font-mono" to="/">
                    PixelPulse
                </Link>
            </h1>
            <nav className="flex items-center m-0 font-mono text-2xl">
                <Link to="/catalogue">All games</Link>
                {/* <!-- Logged-in users --> */}
                <div id="user">
                    <Link to="/create">Create Game</Link>
                    <Link to="/logout">Logout</Link>
                </div>
                {/* <!-- Guest users --> */}
                <div id="guest">
                    <Link to="/login">Login</Link>
                    <Link to="/register">Register</Link>
                </div>
            </nav>
        </header>
    );
}
