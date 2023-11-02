import { createContext, useContext, useMemo } from "react";
import { useNavigate } from "react-router-dom";
import { useQueryClient } from "@tanstack/react-query";
import PropTypes from "prop-types";

const QueryContext = createContext();

export const QueryProvider = ({ children }) => {
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
        <QueryContext.Provider value={contextValues}>
            {children}
        </QueryContext.Provider>
    );
};

export const useQueryContext = () => {
    return useContext(QueryContext);
};

QueryProvider.propTypes = {
    children: PropTypes.object,
};
