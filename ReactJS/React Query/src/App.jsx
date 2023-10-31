import "./App.css";
import PostsList1 from "./PostsList1";
import PostsList2 from "./PostsList2";
import Post from "./Post";
import { useState } from "react";
// /posts -> ["posts"]
// /posts/1 -> ["posts", post.id]
// /posts/?authorId=1 -> ["posts", { authorId: 1}]
// /posts/2/comments -> ["posts", post.id, "comments"]

function App() {
  const [currentPage, setCurrentPage] = useState(<PostsList1 />);

  return (
    <>
      <div>
        <button onClick={() => setCurrentPage(<PostsList1 />)}>
          Posts List 1
        </button>
        <button onClick={() => setCurrentPage(<PostsList2 />)}>
          Posts List 2
        </button>
        <button onClick={() => setCurrentPage(<Post id={1} />)}>
          First Post
        </button>
      </div>
      <br />
      {currentPage}
    </>
  );
}

export default App;
