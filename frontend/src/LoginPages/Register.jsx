import React, { useState } from 'react';
import { registerUser } from '../api';
import { useNavigate } from 'react-router-dom';
import { ROLES, REGISTER_TEXT } from './Constants';
import './Register.css';  

function Register() {
  const navigate = useNavigate();
  const [form, setForm] = useState({
    uname: '',
    email: '',
    password: '',
    phone: '',
    role: ROLES.CUSTOMER,
  });
  const [loading, setLoading] = useState(false);

  const handleChange = (e) => setForm({ ...form, [e.target.name]: e.target.value });

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    try {
      const res = await registerUser(form);
      alert(res.data.message || REGISTER_TEXT.SUCCESS_MESSAGE);

      setForm({
        uname: '',
        email: '',
        password: '',
        phone: '',
        role: ROLES.CUSTOMER,
      });

      navigate('/login'); 
    } catch (err) {
      alert(err.response?.data || REGISTER_TEXT.ERROR_MESSAGE);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="container">
      <div className="form-box">
        <h2>{REGISTER_TEXT.TITLE}</h2>

        <form onSubmit={handleSubmit}>
          <input
            name="uname"
            placeholder={REGISTER_TEXT.USERNAME_PLACEHOLDER}
            value={form.uname}
            onChange={handleChange}
            required
          />
          <input
            name="email"
            type="email"
            placeholder={REGISTER_TEXT.EMAIL_PLACEHOLDER}
            value={form.email}
            onChange={handleChange}
            required
          />
          <input
            name="password"
            type="password"
            placeholder={REGISTER_TEXT.PASSWORD_PLACEHOLDER}
            value={form.password}
            onChange={handleChange}
            required
          />
          <input
            name="phone"
            placeholder={REGISTER_TEXT.PHONE_PLACEHOLDER}
            value={form.phone}
            onChange={handleChange}
            required
          />

          <select name="role" value={form.role} onChange={handleChange}>
            <option value={ROLES.CUSTOMER}>{ROLES.CUSTOMER}</option>
            <option value={ROLES.ADMIN}>{ROLES.ADMIN}</option>
          </select>

          <button type="submit" disabled={loading}>
            {loading ? REGISTER_TEXT.LOADING_BUTTON : REGISTER_TEXT.BUTTON}
          </button>
        </form>

        <p className="link" onClick={() => navigate('/login')}>
          {REGISTER_TEXT.LOGIN_LINK}
        </p>
      </div>
    </div>
  );
}

export default Register;