import { useGetProfileQuery } from "./api";

function Profile() {
  const { data, isLoading, error } = useGetProfileQuery();

  if (isLoading) return <p>Loading...</p>;
  if (error) return <p>Error loading profile</p>;

  return (
    <div>
      <h3>Email: {data?.email}</h3>
      <h3>Role: {data?.role}</h3>
    </div>
  );
}

export default Profile;