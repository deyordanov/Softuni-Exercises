import { createContext, useContext, useMemo } from "react";
import { useNavigate } from "react-router-dom";
import { useQueryClient } from "@tanstack/react-query";
import PropTypes from "prop-types";

const AppQueryContext = createContext();

export const AppQueryProvider = ({ children }) => {
    const navigate = useNavigate();
    const queryClient = useQueryClient();

    const contextValues = useMemo(
        () => ({
            navigate,
            queryClient,
        }),

        [navigate, queryClient]
    );

    return (
        <AppQueryContext.Provider value={contextValues}>
            {children}
        </AppQueryContext.Provider>
    );
};

export const useAppQueryContext = () => {
    return useContext(AppQueryContext);
};

AppQueryProvider.propTypes = {
    children: PropTypes.object,
};
