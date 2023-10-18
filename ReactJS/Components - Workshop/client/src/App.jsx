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
    }, [users]);

    return (
        <>
            <Header />
            <main className="main">
                <section className="card users-container">
                    <SearchBar />

                    <UserList users={users} />
                </section>
            </main>
            <Footer />
        </>
    );
}

export default App;
