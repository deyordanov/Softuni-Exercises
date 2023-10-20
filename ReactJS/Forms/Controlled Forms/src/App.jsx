import { useState, useEffect } from "react";
import "./App.css";

function App() {
  const [formValues, setFormValues] = useState({
    username: "nanami.god",
    password: "nanamiiscool",
    occupation: "sorcerer",
    gender: "male",
    "previous-experience": "None",
    grade: "grade4",
  });

  // useEffect(() => {
  //   setTimeout(() => {
  //     setUsername("megumi.dog");
  //   }, 3000);
  // }, []);

  const onChangeHandler = (e) => {
    setFormValues((state) => ({ ...state, [e.target.name]: e.target.value }));
  };

  useEffect(() => {
    console.log(JSON.stringify(formValues));
  }, [formValues]);

  //Controlled form -> 'value" + 'onChange'
  //Controlled select -> 'value' + 'onChange'
  return (
    <>
      <form>
        <div>
          <label htmlFor="username">Username </label>
          <input
            value={formValues.username}
            onChange={onChangeHandler}
            type="text"
            name="username"
            id="username"
          />
        </div>
        <div>
          <label htmlFor="password">Password </label>
          <input
            value={formValues.password}
            onChange={onChangeHandler}
            type="password"
            name="password"
            id="password"
          />
        </div>

        {/* Controlled Select */}
        <div>
          <label htmlFor="occupation">Occupation </label>
          <select
            value={formValues.occupation}
            onChange={onChangeHandler}
            name="occupation"
            id="occupation"
          >
            <option value="sorcerer">Sorcerer</option>
            <option value="curse">Curse</option>
            <option value="assistant">Assistant</option>
          </select>
        </div>

        {/* Controlled Radio */}
        <div>
          <label htmlFor="male">Male</label>
          <input
            type="radio"
            name="gender"
            id="male"
            value="male"
            checked={formValues.gender === "male"}
            onChange={onChangeHandler}
          />
          <label htmlFor="female">Female</label>
          <input
            type="radio"
            name="gender"
            id="female"
            value="female"
            checked={formValues.gender === "female"}
            onChange={onChangeHandler}
          />
        </div>

        {/* Controlled Textarea */}
        <div>
          <label htmlFor="previous-experience">Previous Experience</label>
          <textarea
            name="previous-experience"
            id="previous-experience"
            cols="30"
            rows="6"
            value={formValues.experience}
            onChange={onChangeHandler}
          ></textarea>
        </div>

        <div>
          <input type="submit" value="Register" />
        </div>
      </form>

      {/* Controlled Checkboxes */}
      <div>
        <label htmlFor="grade"> Grade 4 </label>
        <input
          type="checkbox"
          name="grade"
          id="grade4"
          value="grade4"
          checked={formValues.grade === "grade4"}
          onChange={onChangeHandler}
        />
        <label htmlFor="grade3"> Grade 3 </label>
        <input
          type="checkbox"
          name="grade"
          id="grade3"
          value="grade3"
          checked={formValues.grade === "grade3"}
          onChange={onChangeHandler}
        />
        <label htmlFor="grade2"> Grade 2 </label>
        <input
          type="checkbox"
          name="grade"
          id="grade2"
          value="grade2"
          checked={formValues.grade === "grade2"}
          onChange={onChangeHandler}
        />
        <label htmlFor="grade1"> Grade 1 </label>
        <input
          type="checkbox"
          name="grade"
          id="grade1"
          value="grade1"
          checked={formValues.grade === "grade1"}
          onChange={onChangeHandler}
        />
        <label htmlFor="special-grade"> Special Grade </label>
        <input
          type="checkbox"
          name="grade"
          id="special-grade"
          value="special-grade"
          checked={formValues.grade === "special-grade"}
          onChange={onChangeHandler}
        />
      </div>
    </>
  );
}

export default App;
