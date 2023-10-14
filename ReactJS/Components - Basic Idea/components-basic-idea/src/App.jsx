import "./App.css";
import Counter from "./Components/Counter";
import MovieList from "./Components/MovieList";
import Timer from "./Components/Timer";

function App() {
  const movies = [
    { title: "Godzilla", year: 2023, cast: ["Godzilla", "Henry Cavil"] },
    {
      title: "Harry Potter And The Cursed Child",
      year: 2024,
      cast: ["Daniel Radcliffe", "Villy Yordanova"],
    },
    {
      title: "The Lord of the Rings: The War of the Rohirrim",
      year: 2024,
      cast: ["Denis Yordanov", "Smeagol"],
    },
  ];

  return (
    <div className="App">
      <h1>React Demo</h1>

      <Counter />

      <Timer start={0} />

      <MovieList movies={movies} />
    </div>
  );
}

export default App;
