import { useQuery } from "@tanstack/react-query";
import { getPosts, getUser } from "./api/posts";

export default function Post({ id }) {
  const postQuery = useQuery({
    queryKey: ["posts"],
    queryFn: getPosts,
  });

  const post = Object.values(postQuery.data).filter((x) => x.id === id)[0];

  //   const userQuery = useQuery({
  //     queryKey: ["users", postQuery?.data?.userId],
  //     queryFn: () => getUser(Object.values(postQuery.data).userId),
  //   });

  if (postQuery.isLoading) return <h1>Loading....</h1>;
  if (postQuery.isError) return <h1>{JSON.stringify(postQuery.error)}</h1>;

  return (
    <>
      <h1>
        {post.title} <br />
        UserId: {post.userId}
        {/* <small>
          {userQuery.isLoading
            ? "Loading User...."
            : userQuery.isError
            ? "Error Loading User"
            : userQuery.data.name}
        </small> */}
      </h1>
    </>
  );
}
