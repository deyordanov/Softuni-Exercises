import { useQuery } from "@tanstack/react-query";
import { getPosts } from "./api/posts";

export default function PostsList2() {
  const postsQuery = useQuery({
    queryKey: ["posts"],
    queryFn: getPosts,
  });

  if (postsQuery.isLoading) return <h1>Loading....</h1>;
  if (postsQuery.isError) return <h1>{JSON.stringify(postsQuery.error)}</h1>;

  return (
    <div>
      <h1>Posts List 2</h1>
      <ol>
        {Object.values(postsQuery.data).map((post) => (
          <li key={post.id}>
            {" "}
            {post.title} - {post.body}
          </li>
        ))}
      </ol>
    </div>
  );
}
