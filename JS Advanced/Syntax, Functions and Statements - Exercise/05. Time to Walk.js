function solve(steps, length, speed) {
  const speedInMS = speed / 3.6;
  const rest = Math.floor((steps * length) / 500) * 60;
  const totalTime = (steps * length) / speedInMS + rest;
  const hrs = Math.floor(totalTime / 3600);
  const min = Math.floor(totalTime / 60);
  const sec = Math.round(totalTime % 60);
  console.log(
    `${hrs >= 10 ? hrs : "0" + hrs}:${min >= 10 ? min : "0" + min}:${
      sec >= 10 ? sec : "0" + sec
    }`
  );
}
