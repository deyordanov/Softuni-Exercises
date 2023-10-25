import { useState, useEffect, useRef } from "react";
import "./App.css";

function App() {
  const [name, setName] = useState("");
  const inputRef = useRef();
  // 'useRef' doesn't make our component rerender unlike the approach with 'useEffect'
  // where each time we call the 'setCount' function it rerenders the component
  // const renderCount = useRef(1);
  //renderCount = { current: 0 }

  // useEffect(() => {
  //   renderCount.current = renderCount.current + 1;
  // });

  //Leads to recursion -> not a good way to count how many times our component has rerendered
  //Instead we should use 'useRef'
  // const [count, setCount] = useState(0);
  // useEffect(() => {
  //   setCount((state) => state + 1);
  // });

  //Most common use case for 'useRef'
  const focus = () => {
    inputRef.current.focus();
  };

  return (
    <>
      <input
        ref={inputRef}
        value={name}
        onChange={(e) => setName(e.target.value)}
      />
      <div>My name is {name}</div>
      {/* <div>I rendered {renderCount.current} times!</div> */}
      <button onClick={focus}>Focus</button>
    </>
  );
}

export default App;
