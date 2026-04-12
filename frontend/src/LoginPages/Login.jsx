
import React, { useState } from 'react';
import { useLoginUserMutation, useGetProfileQuery } from '../api';
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { setCredentials } from '../AuthSlice';
import { ROLES, LOGIN_TEXT } from './Constant'
import './Login.css';  

function Login() {
  const navigate = useNavigate();

   const dispatch = useDispatch();
  const [form, setForm] = useState({ email: '', password: '' });
  const [loading, setLoading] = useState(false);
  const [loginUser] = useLoginUserMutation();

  const { data: profile } = useGetProfileQuery(undefined, {
    skip: !localStorage.getItem("token"), 
  });


  const handleChange = (e) => setForm({ ...form, [e.target.name]: e.target.value });

  const handleLogin = async (e) => {
    e.preventDefault();
    setLoading(true);
    try {
      const res = await loginUser(form).unwrap();
      dispatch(setCredentials(res));

      alert(LOGIN_TEXT.SUCCESS_MESSAGE);
      navigate('/'); 
    } catch (err) {
      alert(err.response?.data || LOGIN_TEXT.INVALID_CREDENTIALS);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="container">
      <div className="form-box">
        <h2>{LOGIN_TEXT.TITLE}</h2>

        {!profile && (
          <form onSubmit={handleLogin}>
            <input
              name="email"
              type="email"
              placeholder={LOGIN_TEXT.EMAIL_PLACEHOLDER}
              value={form.email}
              onChange={handleChange}
              required
            />
            <input
              name="password"
              type="password"
              placeholder={LOGIN_TEXT.PASSWORD_PLACEHOLDER}
              value={form.password}
              onChange={handleChange}
              required
            />
            <button type="submit" disabled={loading}>
              {loading ? LOGIN_TEXT.LOADING_BUTTON : LOGIN_TEXT.BUTTON}
            </button>
          </form>
        )}

        {profile && (
          <div>
            <h3>Profile</h3>
            <p>Email: {profile.email}</p>
            <p>Role: {ROLES[profile.role.toUpperCase()] || profile.role}</p>
          </div>
        )}

        <p className="link" onClick={() => navigate('/register')}>
          {LOGIN_TEXT.REGISTER_LINK}
        </p>
      </div>
    </div>
  );
}

export default Login;