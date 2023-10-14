import "./App.css";
import Movie from "./Components/Movie";

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
      <h1>Movie List:</h1>
      <Movie
        title={movies[0].title}
        year={movies[0].year}
        cast={movies[0].cast}
      />

      <Movie
        title={movies[1].title}
        year={movies[1].year}
        cast={movies[1].cast}
      />

      <Movie
        title={movies[2].title}
        year={movies[2].year}
        cast={movies[2].cast}
      />
    </div>
  );
}

export default App;
