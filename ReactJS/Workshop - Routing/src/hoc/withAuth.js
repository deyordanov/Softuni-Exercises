//A function which takes a component as a parameter, decorates it

import { useAuthContext } from "../Contexts/AuthContext";

//and wraps it with another component -> Higher Order Component
export const withAuth = (Component) => {
    //We decorate the given component with 'AuthContext'
    const { AuthContext } = useAuthContext;
    const WrapperComponent = (props) => {
        return <Component {...props} AuthContext={AuthContext} />;
    };

    return WrapperComponent;
};
//The reason HOCs are rarely used is because they create an extra component in the vDOM
//whilst hooks do not!
