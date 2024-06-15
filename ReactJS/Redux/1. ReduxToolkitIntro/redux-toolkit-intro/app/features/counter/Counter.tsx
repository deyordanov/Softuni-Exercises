"use client";

import { useSelector, useDispatch } from "react-redux";
import { increment, decrement, reset, incrementByAmount } from "./counterSlice";
import { useState } from "react";

const Counter = () => {
  const [incrementBy, setIncrementBy] = useState<number | undefined>(0);

  const count = useSelector(
    (state: { counter: { count: number } }) => state.counter.count
  );
  const dispatch = useDispatch();

  const resetAll = () => {
    dispatch(reset());
    setIncrementBy(0);
  };

  return (
    <main className="flex flex-col gap-y-1">
      <div className="bg-white rounded-md text-black px-2 py-1 text-xl">
        {count}
      </div>
      <div className="flex gap-2 bg-blue-400 p-2 rounded-md">
        <button
          className="bg-white rounded-md text-black px-4 text-xl"
          onClick={() => dispatch(increment())}
        >
          +
        </button>
        <button
          className="bg-white rounded-md text-black px-4 text-xl"
          onClick={() => dispatch(decrement())}
        >
          -
        </button>
        <button
          className="bg-white rounded-md text-black px-2 py-1 text-xl"
          onClick={() => resetAll()}
        >
          Reset
        </button>
        <div className="flex gap-2 bg-red-400 p-2 rounded-md">
          <button
            className="bg-white rounded-md text-black px-2 py-1 text-xl"
            onClick={() => dispatch(incrementByAmount(Number(incrementBy)))}
          >
            Increment by:
          </button>
          <input
            className="text-black h-full pl-2"
            type="text"
            value={incrementBy || 0}
            onChange={(e: any) => setIncrementBy(e.target.value)}
          ></input>
        </div>
      </div>
    </main>
  );
};

export default Counter;
