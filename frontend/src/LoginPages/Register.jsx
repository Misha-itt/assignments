import React, { useState } from 'react';
import { useRegisterUserMutation } from '../api';
import { useNavigate } from 'react-router-dom';
import { ROLES, REGISTER_TEXT } from './Constant';
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

    const [registerUser] = useRegisterUserMutation();

  const handleChange = (e) => setForm({ ...form, [e.target.name]: e.target.value });

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    if (!/^\d{10}$/.test(form.phone)) {
    alert("Enter valid 10-digit phone number");
    return;
  }
    try {
        await registerUser(form).unwrap();
      alert( REGISTER_TEXT.SUCCESS_MESSAGE);

      setForm({
        uname: '',
        email: '',
        password: '',
        phone: '',
        role: ROLES.CUSTOMER,
      });

      navigate('/login'); 
    } catch (err) {
  console.log("FULL ERROR:", err);

  const errors = err?.data?.errors;

  if (errors) {
    const messages = Object.entries(errors)
      .map(([field, msgs]) => `${field}: ${msgs.join(", ")}`)
      .join("\n");

    alert(messages);
  } else {
    alert(err?.data?.message || "Registration failed");
  }
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