import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

const baseUrl = "https://swapi.dev/api/vehicles";

export default function Vehicle() {
    const { vehicleId } = useParams();
    const [vehicle, setVehicle] = useState({});

    useEffect(() => {
        fetch(`${baseUrl}/${vehicleId}`)
            .then((response) => response.json())
            .then((data) => setVehicle(data));
    }, [vehicleId]);

    return <h1>{vehicle.name}</h1>;
}
