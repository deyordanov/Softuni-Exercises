import style from "./Navigation.module.css";
import PropTypes from "prop-types";

export default function Navigation({ children }) {
    return (
        <nav>
            <ul className={style.navigation}>{children}</ul>
        </nav>
    );
}

Navigation.propTypes = {
    children: PropTypes.array,
};
