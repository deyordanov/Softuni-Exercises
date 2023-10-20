import { useState, useEffect } from "react";
import "./App.css";

function App() {
  const [defaultUsername, setDefaultUsername] = useState("nanami.god");

  //Uncontrolled event
  useEffect(() => {
    setTimeout(() => {
      setDefaultUsername("megumi.dog");
    }, 3000);
  }, []);

  //Uncontrolled event
  const handleUsernameChange = () => {
    console.log("Changed!");
  };

  //Uncontrolled event
  // const handleOnClick = (e) => {
  //   e.preventDefault();
  //   console.log(
  //     e.target.parentElement.parentElement.querySelector("#username").value
  //   );
  // };

  //Uncontrolled event
  const handleOnSubmit = (e) => {
    e.preventDefault();
    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);
    console.log(data.username);
  };

  return (
    //Uncontrolled form
    <form onSubmit={handleOnSubmit}>
      <div>
        <label htmlFor="username">Username </label>
        <input
          onChange={handleUsernameChange}
          defaultValue={defaultUsername}
          type="text"
          name="username"
          id="username"
        />
      </div>
      <div>
        <label htmlFor="password">Password </label>
        <input type="password" name="password" id="password" />
      </div>
      <div>
        <input
          // onClick={(e) => handleOnClick(e)}
          type="submit"
          value="Register"
        />
      </div>
    </form>
  );
}

export default App;
