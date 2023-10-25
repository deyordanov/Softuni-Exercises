import { useState, useMemo, useEffect } from "react";

function slowFunction(num) {
  console.log("Calling Slow Function!");
  for (let i = 0; i <= 10000000000 / 2; i++) {}
  return num * 2;
}

function App() {
  const [number, setNumber] = useState(0);
  const [dark, setDark] = useState(false);
  //Storing the result of the function, if the value of 'number' is the same as before
  //Otherwise we will call the 'slowFunction' and set the value of 'number'
  //This way we won't call the function each time the component is re-rendered and slow down our application
  const doubleNumber = useMemo(() => {
    return slowFunction(number);
  }, [number]);

  //Creating a new object only when the 'dark' variable is changed - by usin 'useMemo'
  //Otherwise a new object would be created every time we re-render
  const theme = useMemo(() => {
    return {
      backgroundColor: dark ? "black" : "white",
      color: dark ? "white" : "black",
    };
  }, [dark]);

  useEffect(() => {
    console.log("Theme Changed");
  }, [theme]);

  return (
    <>
      <input
        type="number"
        value={number}
        onChange={(e) => setNumber(parseInt(e.target.value))}
      />

      <button onClick={() => setDark((prevDark) => !prevDark)}>
        Change Theme
      </button>
      <div style={theme}>{doubleNumber}</div>
    </>
  );
}

export default App;
