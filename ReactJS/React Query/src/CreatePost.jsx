import { createPost } from "./api/posts";
import { useState } from "react";

export default function CreatePost() {
  const [formValues, setFormValues] = useState({
    title: "",
    body: "",
    id: 0,
    userId: 0,
  });

  const onSubmitHandler = (e) => {
    e.preventDefault();
    createPost(formValues);
    setFormValues({
      title: "",
      body: "",
    });
  };

  const onChangeHandler = (e) => {
    setFormValues((state) => ({ ...state, [e.target.name]: e.target.value }));
  };

  return (
    <form onSubmit={onSubmitHandler}>
      <div>
        <label htmlFor="title">Title: </label>
        <input type="text" name="title" id="title" onChange={onChangeHandler} />
      </div>
      <div>
        <label htmlFor="body">Body: </label>
        <input type="text" name="body" id="body" onChange={onChangeHandler} />
      </div>
      <div>
        <label htmlFor="id">Id: </label>
        <input type="number" name="id" id="id" onChange={onChangeHandler} />
      </div>
      <div>
        <label htmlFor="userId">User Id: </label>
        <input
          type="number"
          name="userId"
          id="userId"
          onChange={onChangeHandler}
        />
      </div>
      <button>Submit</button>
    </form>
  );
}
