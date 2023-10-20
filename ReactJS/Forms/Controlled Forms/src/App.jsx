import { useState, useEffect } from "react";
import "./App.css";

function App() {
  const [username, setUsername] = useState("nanami.god");
  const [password, setPassword] = useState("nanamiiscool");
  const [occupation, setOccupation] = useState("sorcerer");
  const [gender, setGender] = useState("male");
  const [experience, setExperience] = useState("None");
  const [grade, setGrade] = useState("grade4");

  useEffect(() => {
    setTimeout(() => {
      setUsername("megumi.dog");
    }, 3000);
  }, []);

  const onUsernameChange = (e) => {
    setUsername(e.target.value);
  };

  // useEffect(() => {
  //   console.log(username);
  // }, [username]);

  const onPasswordChange = (e) => {
    setPassword(e.target.value);
  };

  // useEffect(() => {
  //   console.log(password);
  // }, [password]);

  const onOccupationChange = (e) => {
    setOccupation(e.target.value);
  };

  // useEffect(() => {
  //   console.log(occupation);
  // }, [occupation]);

  const onGenderChange = (e) => {
    setGender(e.target.value);
  };

  // useEffect(() => {
  //   console.log(gender);
  // }, [gender]);

  const onExperienceChange = (e) => {
    setExperience(e.target.value);
  };

  // useEffect(() => {
  //   console.log(experience);
  // }, [experience]);

  const onGradeChange = (e) => {
    setGrade(e.target.value);
  };

  // useEffect(() => {
  //   console.log(grade);
  // }, [grade]);

  //Controlled form -> 'value" + 'onChange'
  //Controlled select -> 'value' + 'onChange'
  return (
    <>
      <form>
        <div>
          <label htmlFor="username">Username </label>
          <input
            value={username}
            onChange={onUsernameChange}
            type="text"
            name="username"
            id="username"
          />
        </div>
        <div>
          <label htmlFor="password">Password </label>
          <input
            value={password}
            onChange={onPasswordChange}
            type="password"
            name="password"
            id="password"
          />
        </div>

        {/* {username === "nanamikento" ? <p>Hello there!</p> : <p>No!</p>} */}

        {/* Uncontrolled Select */}
        {/* <div>
          <label htmlFor="occupation">Occupation </label>
          <select name="occupation" id="occupation" defaultValue="sorcerer">
            <option value="sorcerer">Sorcerer</option>
            <option value="curse">Curse</option>
            <option value="assistant">Assistant</option>
          </select>
        </div> */}

        {/* Controlled Select */}
        <div>
          <label htmlFor="occupation">Occupation </label>
          <select
            value={occupation}
            onChange={onOccupationChange}
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
            checked={gender === "male"}
            onChange={onGenderChange}
          />
          <label htmlFor="female">Female</label>
          <input
            type="radio"
            name="gender"
            id="female"
            value="female"
            checked={gender === "female"}
            onChange={onGenderChange}
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
            value={experience}
            onChange={onExperienceChange}
          ></textarea>
        </div>

        <div>
          <input type="submit" value="Register" />
        </div>
      </form>

      {/* Controlled Checkboxes */}
      <div>
        <label htmlFor="grade4"> Grade 4 </label>
        <input
          type="checkbox"
          name="grade4"
          id="grade4"
          value="grade4"
          checked={grade === "grade4"}
          onChange={onGradeChange}
        />
        <label htmlFor="grade3"> Grade 3 </label>
        <input
          type="checkbox"
          name="grade3"
          id="grade3"
          value="grade3"
          checked={grade === "grade3"}
          onChange={onGradeChange}
        />
        <label htmlFor="grade2"> Grade 2 </label>
        <input
          type="checkbox"
          name="grade2"
          id="grade2"
          value="grade2"
          checked={grade === "grade2"}
          onChange={onGradeChange}
        />
        <label htmlFor="grade1"> Grade 1 </label>
        <input
          type="checkbox"
          name="grade1"
          id="grade1"
          value="grade1"
          checked={grade === "grade1"}
          onChange={onGradeChange}
        />
        <label htmlFor="special-grade"> Special Grade </label>
        <input
          type="checkbox"
          name="special-grade"
          id="special-grade"
          value="special-grade"
          checked={grade === "special-grade"}
          onChange={onGradeChange}
        />
      </div>
    </>
  );
}

export default App;
