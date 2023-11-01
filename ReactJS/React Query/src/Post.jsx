import { useQuery } from "@tanstack/react-query";
import { getPost, getUsers } from "./api/posts";

export default function Post({ id }) {
  const postQuery = useQuery({
    queryKey: ["posts", id],
    queryFn: () => getPost(id),
  });

  const userQuery = useQuery({
    queryKey: ["users"],
    enabled: postQuery?.data?.userId != null,
    queryFn: getUsers,
  });

  const user = userQuery.data
    ? Object.values(userQuery.data).filter(
        (x) => x.id === postQuery?.data?.userId
      )[0]
    : null;

  if (postQuery.isLoading) return <h1>Loading....</h1>;
  if (postQuery.isError) return <h1>{JSON.stringify(postQuery.error)}</h1>;

  return (
    <>
      <h1>
        {postQuery.data.title} - {postQuery.data.body}
        <br />
        {postQuery.data.userId}
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
