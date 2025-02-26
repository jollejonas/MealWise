import axios from 'axios';
import {jwtDecode} from "jwt-decode";

const API_URL = "https://localhost:7104/api/auth/";

export const login = async (username, password) => {
    try {
        const response = await axios.post(API_URL + "login", {
            username,
            password,
        },
        { headers: { "Content-Type": "application/json" } } );
        localStorage.setItem("token", response.data.token);
        window.dispatchEvent(new Event("storage"));
        return response.data;
    } catch (error) {
        console.error("Login fejlede:", error.response?.data || error.message);
        throw error;
    }
};

export const register = async (username, email, password) => {
    try 
    {
        const response = await axios.post(API_URL + "register", {
            username,
            email,
            password,
        },
        { headers: { "Content-Type": "application/json" } } );
        
        return response.data;
    } catch (error) {
        console.error("Registrering fejlede:", error.response?.data || error.message);
        throw error;
    }
};


export const logout = () => {
    localStorage.removeItem("token");
    window.dispatchEvent(new Event("storage"));
};

export const getToken = () => {
    return localStorage.getItem("token");
};

export const isAuthenticated = () => {
    return !!getToken();
};

export const getUserIdFromToken = () => {
    const token = getToken();
    if (!token) return null;
    
    try {
        const decoded = jwtDecode(token);
        return decoded.sub;
    } catch (error) {
        console.error("Kunne ikke dekode token:", error);
        return null;
    }
};
