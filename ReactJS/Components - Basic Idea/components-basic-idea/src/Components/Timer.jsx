import PropTypes from "prop-types";
import { useState } from "react";

const Timer = (props) => {
  const [seconds, setSeconds] = useState(props.start);

  //Not good practice -> useEffect is better
  //Increments the value be 2 because of the strict mode, which prerenders everything twice
  setTimeout(() => {
    setSeconds((state) => state + 1);
  }, 1000);

  return (
    <div>
      <h3>Timer</h3>
      Time: {seconds}s
    </div>
  );
};

Timer.propTypes = {
  start: PropTypes.number,
};

export default Timer;
