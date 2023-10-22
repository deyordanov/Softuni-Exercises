import Navigation from "./Navigation";
import { NavLink } from "react-router-dom";

export default function MainNavigation() {
    return (
        <Navigation>
            {/* With anchor tags we will always refresh the page */}
            {/* <li>
                    <a href="/">Home</a>
                </li>
                <li>
                    <a href="/about">About</a>
                </li> */}

            {/* This way we do not refresh the page  */}
            {/* NavLink -> +style && +className */}
            <li>
                <NavLink
                    style={({ isActive }) => ({
                        color: isActive ? "lime" : "",
                    })}
                    // className={({ isActive }) =>
                    //     isActive ? style["nav-active"] : ""
                    // }
                    to={"/"}
                >
                    Home
                </NavLink>
            </li>
            <li>
                <NavLink
                    style={({ isActive }) => ({
                        color: isActive ? "lime" : "",
                    })}
                    // className={({ isActive }) =>
                    //     isActive ? style["nav-active"] : ""
                    // }
                    to={"/about"}
                >
                    About
                </NavLink>
            </li>
            <li>
                <NavLink
                    style={({ isActive }) => ({
                        color: isActive ? "lime" : "",
                    })}
                    // className={({ isActive }) =>
                    //     isActive ? style["nav-active"] : ""
                    // }
                    to={"/characters"}
                >
                    Characters
                </NavLink>
            </li>
        </Navigation>
    );
}
