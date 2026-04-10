import { useDispatch } from "react-redux";
import { logout } from "../AuthSlice";

function LogoutButton() {
  const dispatch = useDispatch();

  return (
    <button onClick={() => dispatch(logout())}>
      Logout
    </button>
  );
}

export default LogoutButton;