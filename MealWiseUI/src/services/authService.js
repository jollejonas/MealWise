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

export const getUserInfoFromToken = () => {
    const token = getToken();
    if (!token) return { userId: null, role: null};
    
    try {
        const decoded = jwtDecode(token);
        console.log("Decoded token data:", decoded);

        const roleClaim = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
        const role = decoded[roleClaim] || null;
        console.log(role);
        return {
            userId: decoded.sub || null,
            role: role,
        };
    } catch (error) {
        console.error("Kunne ikke dekode token:", error);
        return { userId: null, role: null};
    }
};

export const hasRole = (requiredRole) => {
    const { role }  = getUserInfoFromToken();
    if(!role) return false;

    const rolesHierarchy = {
        "User": 0,
        "Admin": 1,
    };

    console.log(rolesHierarchy[role]);
    console.log(rolesHierarchy[requiredRole]);

    return rolesHierarchy[role] >= rolesHierarchy[requiredRole];
}
