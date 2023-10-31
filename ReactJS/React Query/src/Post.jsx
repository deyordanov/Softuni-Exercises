import { useQuery } from "@tanstack/react-query";
import { getPosts, getUsers } from "./api/posts";

export default function Post({ id }) {
  const postQuery = useQuery({
    queryKey: ["posts"],
    queryFn: getPosts,
  });

  const post = postQuery.data
    ? Object.values(postQuery?.data).filter((x) => x.id === id)[0]
    : null;

  const userQuery = useQuery({
    queryKey: ["users"],
    enabled: post?.userId != null,
    queryFn: getUsers,
  });

  const user = userQuery.data
    ? Object.values(userQuery.data).filter((x) => `${x.id}` === post?.userId)[0]
    : null;

  if (postQuery.isLoading) return <h1>Loading....</h1>;
  if (postQuery.isError) return <h1>{JSON.stringify(postQuery.error)}</h1>;

  return (
    <>
      <h1>
        {post.title} - {post.body}
        <br />
        {post.userId}
        <small>
          <br />
          {userQuery.isLoading
            ? "Loading User...."
            : userQuery.isError
            ? "Error Loading User"
            : user.name}
        </small>
      </h1>
    </>
  );
}
