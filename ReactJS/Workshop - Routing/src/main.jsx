import ReactDOM from "react-dom/client";
import { BrowserRouter } from "react-router-dom";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import App from "./App.jsx";

import { QueryProvider } from "./Contexts/QueryContext.jsx";
import { GameProvider } from "./Contexts/GameContext.jsx";

const queryClient = new QueryClient();

ReactDOM.createRoot(document.getElementById("root")).render(
    <QueryClientProvider client={queryClient}>
        <BrowserRouter>
            <QueryProvider>
                <GameProvider>
                    <App />
                </GameProvider>
            </QueryProvider>
        </BrowserRouter>
    </QueryClientProvider>
);
