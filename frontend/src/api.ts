import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { API_BASE_URL } from "./config";


interface RegisterUserDto {
  uname: string;
  email: string;
  password: string;
  phone: string;
  role: string;
}

interface LoginUserDto {
  email: string;
  password: string;
}

interface AuthResponse {
  token: string;
  user: {
    email: string;
    role: string;
  };
}

interface UserProfile {
  email: string;
  role: string;
}

export const api = createApi({
  reducerPath: "api",

  baseQuery: fetchBaseQuery({
    baseUrl: API_BASE_URL,

    
    prepareHeaders: (headers, { getState }) => {
      const token = (getState() as any).auth.token;

      if (token) {
        headers.set("Authorization", `Bearer ${token}`);
      }

      return headers;
    },
  }),

  endpoints: (builder) => ({
    registerUser: builder.mutation<void, RegisterUserDto>({
      query: (body) => ({
        url: "user/register",
        method: "POST",
        body,
      }),
    }),

    loginUser: builder.mutation<AuthResponse, LoginUserDto>({
      query: (body) => ({
        url: "user/login",
        method: "POST",
        body,
      }),
    }),

    getProfile: builder.query<UserProfile, void>({
      query: () => "user/profile",
    }),
  }),
});

export const {
  useRegisterUserMutation,
  useLoginUserMutation,
  useGetProfileQuery,
} = api;