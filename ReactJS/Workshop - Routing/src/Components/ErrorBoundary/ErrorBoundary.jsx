import { Component } from "react";
import PropTypes from "prop-types";

export default class ErrorBoundary extends Component {
    constructor(props) {
        super(props);

        this.state = {
            hasError: false,
        };
    }

    static getDerivedStateFormError(error) {
        console.log("getDerivedStateFormError");
        console.log(error);

        return { hasError: true };
    }

    //Used only in production (not in development) ->
    //TODO: Create an Error-Displaying Page for production
    render() {
        if (this.state.hasError) {
            return <h1>ERRORRRRRRRRRRRRRRR</h1>;
        }

        return <>{this.props.children}</>;
    }
}

ErrorBoundary.propTypes = {
    children: PropTypes.object,
};
