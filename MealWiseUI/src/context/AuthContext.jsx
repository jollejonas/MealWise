import { createContext, useState, useEffect, useContext } from 'react';
import { isAuthenticated, getUserInfoFromToken, logout } from '../services/authService';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [userId, setUserId] = useState(null);
    const [role, setRole] = useState(null);
    const [isLoggedIn, setIsLoggedIn] = useState(isAuthenticated());

    useEffect(() => {
        const updateAuthStatus = () => {
            const loggedIn = isAuthenticated();
            setIsLoggedIn(loggedIn);

            if(loggedIn){
                const { userId, role } = getUserInfoFromToken();
                setUserId(userId);
                setRole(role);
            } else {
                setUserId(null);
                setRole(null);
            }
        };

        updateAuthStatus();

        window.addEventListener("storage", updateAuthStatus);
        return () => window.removeEventListener("storage", updateAuthStatus);
    }
    , []);

    const handleLogout = () => {
        logout();
        setIsLoggedIn(false);
        setUserId(null);
        setRole(null);
    };

    return(
        <AuthContext.Provider value={{ userId, role, isLoggedIn, handleLogout }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => {
    const context = useContext(AuthContext);
    if (!context) {
        throw new Error("useAuth must be used within an AuthProvider");
    }
    return context;
};