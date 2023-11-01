// src/hooks/usePreviousLocation.js
import { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";

let lastLocation = null;

export default function usePreviousLocation() {
    const location = useLocation();
    const [previousLocation, setPreviousLocation] = useState(lastLocation);

    useEffect(() => {
        setPreviousLocation(lastLocation);
        lastLocation = location; // update lastLocation after rendering
    }, [location]);

    return previousLocation;
}
