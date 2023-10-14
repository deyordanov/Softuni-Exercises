import { useState } from "react";

const getTitle = (count) => {
  switch (count) {
    case 1:
      return "First Blood!";
    case 2:
      return "Double Kill!";
    case 3:
      return "Triple Kill!";
    case 4:
      return "Quadra Kill!";
    case 5:
      return "Penta Kill!";
    default:
      return "Counter";
  }
};

const Counter = () => {
  const [counter, setCounter] = useState(0);

  const incrementCounterHandler = () => {
    setCounter((state) => state + 1);
  };

  const decrementCounterHandler = () => {
    setCounter((state) => state - 1);
  };

  const clearCounterHandler = () => {
    setCounter(0);
  };

  return (
    <div>
      <h3 style={{ color: counter < 0 ? "red" : "green" }}>
        {getTitle(counter)}: {counter}
      </h3>
      <button onClick={incrementCounterHandler}>+</button>
      <button onClick={clearCounterHandler}>CLEAR</button>
      <button onClick={decrementCounterHandler}>-</button>
    </div>
  );
};

export default Counter;
