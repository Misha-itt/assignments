
import React, { useState } from 'react';
import { loginUser, getProfile } from '../api';
import { useNavigate } from 'react-router-dom';
import { ROLES, LOGIN_TEXT } from './Constant'
import './Login.css';  

function Login() {
  const navigate = useNavigate();
  const [form, setForm] = useState({ email: '', password: '' });
  const [profile, setProfile] = useState(null);
  const [loading, setLoading] = useState(false);

  const handleChange = (e) => setForm({ ...form, [e.target.name]: e.target.value });

  const handleLogin = async (e) => {
    e.preventDefault();
    setLoading(true);
    try {
      const res = await loginUser(form);
      const token = res.data.token || res.data.Token;
      localStorage.setItem('token', token);

      const profileRes = await getProfile(token);
      setProfile(profileRes.data);

      alert(LOGIN_TEXT.SUCCESS_MESSAGE);
      navigate('/'); // redirect after login
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