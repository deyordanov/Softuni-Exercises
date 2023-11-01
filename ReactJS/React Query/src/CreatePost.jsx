import { createPost } from "./api/posts";
import { useRef } from "react";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import Post from "./Post";

// eslint-disable-next-line react/prop-types
export default function CreatePost({ setCurrentPage }) {
  const titleRef = useRef();
  const bodyRef = useRef();
  const queryClient = useQueryClient();
  const createPostMutation = useMutation({
    mutationFn: createPost,
    onSuccess: (data) => {
      queryClient.setQueryData(["posts", data._id], data);
      queryClient.invalidateQueries(["posts"], { exat: true });
      setCurrentPage(<Post id={data._id} />);
    },
    //Peformed before the mutationFn - here we create our context
    // onMutate: (variables) => {
    //   return { cat: "Meowskers" };
    // },
  });

  const onSubmitHandler = (e) => {
    e.preventDefault();
    createPostMutation.mutate({
      title: titleRef.current.value,
      body: bodyRef.current.value,
    });
  };

  return (
    <>
      {createPostMutation.isError && JSON.stringify(createPostMutation.error)}
      <h1>Create Post</h1>
      <form onSubmit={onSubmitHandler}>
        <div>
          <label htmlFor="title">Title: </label>
          <input ref={titleRef} type="text" name="title" id="title" />
        </div>
        <div>
          <label htmlFor="body">Body: </label>
          <input ref={bodyRef} type="text" name="body" id="body" />
        </div>
        <button disabled={createPostMutation.isLoading}>
          {createPostMutation.isLoading ? "Loading..." : "Create"}
        </button>
      </form>
    </>
  );
}
