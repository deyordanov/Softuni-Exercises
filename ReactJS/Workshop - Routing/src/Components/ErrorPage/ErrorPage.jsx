import { Link } from "react-router-dom";

export default function ErrorPage() {
    return (
        <div className="flex h-screen  px-4 items-center justify-center">
            <div className="text-center">
                <h1 className="font-black text-gray-200 text-9xl">404</h1>

                <p className="text-6xl font-bold tracking-tight text-red-600">
                    Uh-oh!
                </p>

                <p className="mt-4 text-2xl text-gray-400">
                    We can`t find that page.
                </p>

                <Link
                    to="/"
                    className="btn submit bg-slate-700  hover:shadow-lg hover:shadow-white hover:bg-slate-900"
                >
                    Go Back Home
                </Link>
            </div>
        </div>
    );
}
