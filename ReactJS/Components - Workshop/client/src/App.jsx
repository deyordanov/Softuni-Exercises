import "./App.css";
import * as userService from "./Services/userService";
import { useState, useEffect } from "react";

import Footer from "./Components/Footer";
import Header from "./Components/Header";
import SearchBar from "./Components/SearchBar";
import UserList from "./Components/UserList";

function App() {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        // async function getUsers() {
        //     return await userService.getAll();
        // }
        userService
            .getAll()
            .then((response) => {
                setUsers(response);
            })
            .catch((err) => {
                console.log(err);
            });
    }, []);

    async function handleSearch(criteria, value) {
        const users = await userService.getAll();
        setUsers(
            users.filter((u) => (value === "" ? true : u[criteria] === value))
        );
    }

    return (
        <>
            <Header />
            <main className="main">
                <section className="card users-container">
                    <SearchBar handleSearch={handleSearch} />

                    <UserList
                        users={users}
                        handleSearch={handleSearch}
                        setUsers={setUsers}
                    />
                </section>
            </main>
            <Footer />
        </>
    );
}

export default App;
