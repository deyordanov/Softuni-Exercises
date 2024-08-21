"use client";

import { createSlice } from "@reduxjs/toolkit";

const initialState: counterSliceType = {
  count: 0,
};

type counterSliceType = {
  count: number;
};

export const counterSlice = createSlice({
  name: "counter",
  initialState,
  reducers: {
    increment: (state: counterSliceType) => {
      state.count += 1;
    },
    decrement: (state: counterSliceType) => {
      state.count -= 1;
    },
    reset: (state: counterSliceType) => {
      state.count = 0;
    },
    incrementByAmount: (state: counterSliceType, actions) => {
      state.count += actions.payload;
    },
  },
});

export const { increment, decrement, reset, incrementByAmount } =
  counterSlice.actions;

export default counterSlice.reducer;
