import { Routes, Route } from "react-router-dom";
import { AuthProvider } from "./Contexts/AuthContext";
import ErrorBoundary from "./Components/ErrorBoundary/ErrorBoundary";
import RouteGuard from "./Components/common/RouteGuard";

import { DetailsProvider } from "./Contexts/DetailsContext";

// import { withAuth } from "./hoc/withAuth";
import Header from "./Components/Header/Header";
import Main from "./Components/Main/Main";
import Home from "./Components/Home/Home";
import Login from "./Components/Login/Login";
import Register from "./Components/Register/Register";
import Create from "./Components/Create/Create";
import Catalogue from "./Components/Catalogue/Catalogue";
import Details from "./Components/Catalogue/CatalogueItem/Details/Details";
import Edit from "./Components/Edit/Edit";
import Logout from "./Components/Logout/Logout";

import "bootstrap/dist/css/bootstrap.min.css";
import "../public/styles/style.css";
import ErrorPage from "./Components/ErrorPage/ErrorPage";

function App() {
    // const HOC = withAuth(Login);
    return (
        <ErrorBoundary>
            <AuthProvider>
                <div
                    id="box"
                    className="flex flex-col w-full overflow-y-auto h-screen box-border"
                >
                    <Header />
                    <Main />

                    {/* Adding more contexts than necessary purely for practice! */}
                    <Routes>
                        <Route path="/" element={<Home />} />
                        {/* <Route path="/login" element={<HOC props={props} />}></Route> */}
                        <Route path="/login" element={<Login />}></Route>
                        <Route path="/register" element={<Register />}></Route>
                        <Route
                            path="/catalogue"
                            element={<Catalogue />}
                        ></Route>

                        <Route element={<RouteGuard />}>
                            <Route path="/create" element={<Create />}></Route>
                            <Route
                                path="/catalogue/:gameId/edit"
                                element={<Edit />}
                            ></Route>
                            <Route
                                path="/catalogue/:gameId"
                                element={
                                    <DetailsProvider>
                                        <Details />
                                    </DetailsProvider>
                                }
                            ></Route>
                            <Route path="/logout" element={<Logout />}></Route>
                        </Route>

                        <Route path="*" element={<ErrorPage />} />
                    </Routes>
                </div>
            </AuthProvider>
        </ErrorBoundary>
    );
}

export default App;
