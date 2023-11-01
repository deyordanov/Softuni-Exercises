import { Link } from "react-router-dom";

export default function ErrorPage() {
    return (
        <main className="h-screen w-full flex flex-col justify-center items-center">
            <h1 className="p-0 text-[280px] font-extrabold text-white tracking-widest">
                404
            </h1>
            <div className="bg-[#FF6A3D] p-2 text-5xl rounded rotate-12 absolute">
                Page Not Found
            </div>
            <Link
                to={"/"}
                className="btn submit bg-slate-700 hover:shadow-lg hover:shadow-white hover:bg-slate-900"
            >
                Go Home
            </Link>
        </main>
    );
}
