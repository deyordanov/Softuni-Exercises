import Description from "./Components/Description";
import Footer from "./Components/Footer";
import Header from "./Components/Header";
import Navigation from "./Components/Navigation";
import Schedule from "./Components/Schedule";
import Speakers from "./Components/Speakers";
import Tickets from "./Components/Tickets";

function App() {
  return (
    <div>
      <Navigation />
      <Header />
      <div className="container">
        <Description />
        <Speakers />
      </div>

      <Tickets />

      <Schedule />

      <Footer />
    </div>
  );
}

export default App;
