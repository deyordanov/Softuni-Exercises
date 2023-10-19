import "./App.css";
import { useState, useCallback } from "react";
import List from "./Components/List";

function App() {
  const [number, setNumber] = useState(1);
  const [dark, setDark] = useState(false);

  //Storing the function itself based on whether the 'number' variable has changed its value
  //Instead of creating the function every time we re-render the component, we can do it only when the 'number' changes
  const getItems = useCallback(
    (incrementer) => {
      return [number, number + incrementer, number + incrementer * 2];
    },
    [number]
  );

  const theme = {
    backgroundColor: dark ? "#333" : "#FFF",
    color: dark ? "#FFF" : "#333",
  };

  return (
    <>
      <div style={theme}>
        <input
          type="number"
          value={number}
          onChange={(e) => setNumber(parseInt(e.target.value))}
        />
        <button onClick={() => setDark((prevDark) => !prevDark)}>
          Toggle theme
        </button>
        <List getItems={getItems} />
      </div>
    </>
  );
}

export default App;
