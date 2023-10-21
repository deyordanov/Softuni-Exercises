import { Routes, Route } from "react-router-dom";
import "./App.css";
import Home from "./Components/Home";
import About from "./Components/About";
import Error from "./Components/Error";
import Navigation from "./Components/Navigation";
import CharacterList from "./Components/CharacterList";
import Character from "./Components/Character";
import Movie from "./Components/Movie";
import Starship from "./Components/Starship";
import Vehicle from "./Components/Vehicle";

function App() {
    return (
        <>
            <Navigation />
            <Routes>
                <Route path="*" element={<Error />} />
                <Route path="/" element={<Home />} />
                <Route path="/about" element={<About />} />
                <Route path="/characters" element={<CharacterList />} />
                <Route
                    path="/characters/:characterId/*"
                    element={<Character />}
                />
                <Route path="/movies/:movieId" element={<Movie />}></Route>
                <Route
                    path="/starships/:starshipId"
                    element={<Starship />}
                ></Route>
                <Route
                    path="/vehicles/:vehicleId"
                    element={<Vehicle />}
                ></Route>
            </Routes>
        </>
    );
}

export default App;
