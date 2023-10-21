import { useState, useEffect, useCallback } from "react";
import CharacterListItem from "./CharacterListItem";

const baseUrl = "https://swapi.dev/api/people";

export default function CharacterList() {
    const [characters, setCharacters] = useState([]);

    const fetchData = useCallback((url) => {
        fetch(url)
            .then((res) => res.json())
            .then((data) => {
                setCharacters((state) => [...state, ...data.results]);

                if (data.next) {
                    fetchData(data.next);
                }
            });
    }, []);

    useEffect(() => {
        fetchData(baseUrl);
    }, [fetchData]);

    return (
        <>
            <h1>Star Wars Characters</h1>
            {characters.map((x) => (
                <CharacterListItem
                    key={x.url
                        .split("/")
                        .filter((x) => x)
                        .pop()}
                    {...x}
                />
            ))}
        </>
    );
}
