import { Routes, Route, useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";

import { AuthContext } from "./Contexts/AuthContext";
import * as gameService from "./Services/gameService";
import * as authService from "./Services/authService";

import Header from "./Components/Header/Header";
import Main from "./Components/Main/Main";
import Home from "./Components/Home/Home";
import Login from "./Components/Login/Login";
import Register from "./Components/Register/Register";
import Create from "./Components/Create/Create";
import Catalogue from "./Components/Catalogue/Catalogue";
import Details from "./Components/Catalogue/CatalogueItem/Details/Details";
import Logout from "./Components/Logout/Logout";

import "bootstrap/dist/css/bootstrap.min.css";
import "../public/styles/style.css";

function App() {
    const [games, setGames] = useState([]);
    const [auth, setAuth] = useState({});
    const navigate = useNavigate();

    useEffect(() => {
        gameService
            .getAll()
            .then((data) => {
                setGames(data);
            })
            .catch((error) => console.log(error));
    }, []);

    const onCreateSubmit = async (data) => {
        const newGame = await gameService.create({
            ...data,
            token: auth.accessToken,
        });

        setGames((state) => [...state, newGame]);

        navigate("/catalogue");
    };

    const onLoginSubmit = async (data) => {
        try {
            const response = await authService.login(data);

            setAuth(response);

            navigate("/catalogue");
        } catch (error) {
            console.log("Invalid email or password!");
        }
    };

    const onRegisterSubmit = async (data) => {
        try {
            const response = await authService.register(data);

            setAuth(response);

            navigate("/catalogue");
        } catch (error) {
            console.log("Couldn`t register!");
        }
    };

    const onLogout = async () => {
        // await authService.logout();

        setAuth({});
    };

    const contextData = {
        onLoginSubmit,
        onRegisterSubmit,
        onLogout,
        userId: auth._id,
        userEmail: auth.email,
        token: auth.accessToken,
        isAuthenticated: !!auth.accessToken,
    };

    return (
        <AuthContext.Provider value={contextData}>
            <div
                id="box"
                className="flex flex-col w-full overflow-y-auto h-screen box-border"
            >
                <Header />
                <Main />

                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/login" element={<Login />}></Route>
                    <Route path="/logout" element={<Logout />}></Route>
                    <Route path="/register" element={<Register />}></Route>
                    <Route
                        path="/create"
                        element={<Create onCreateSubmit={onCreateSubmit} />}
                    ></Route>
                    <Route
                        path="/catalogue"
                        element={<Catalogue games={games} />}
                    ></Route>
                    <Route
                        path="/catalogue/:gameId"
                        element={<Details />}
                    ></Route>
                </Routes>
            </div>
        </AuthContext.Provider>
    );
}

export default App;
