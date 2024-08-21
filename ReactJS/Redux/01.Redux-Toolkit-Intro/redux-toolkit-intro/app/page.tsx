"use client";

import Counter from "./features/counter/Counter";

export default function Home() {
  return (
    <>
      <div className="flex w-full h-screen justify-center items-center">
        <Counter />
      </div>
    </>
  );
}
