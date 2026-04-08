import axios from 'axios';
import { API_BASE_URL } from './config';


const api = axios.create({
  baseURL: API_BASE_URL,
  headers: { 'Content-Type': 'application/json' },
});


export interface RegisterUserDto {
  uname: string;
  email: string;
  password: string;
  phone: string;
  role: string;
}

export interface LoginUserDto {
  email: string;
  password: string;
}

export interface UserProfile {
  email: string;
  role: string;
}


export const registerUser = (user: RegisterUserDto) => {
  return api.post('/user/register', user);
};

export const loginUser = (user: LoginUserDto) => {
  return api.post('/user/login', user);
};

export const getProfile = (token: string) => {
  return api.get<UserProfile>('/user/profile', {
    headers: { Authorization: `Bearer ${token}` },
  });
};

export default api;