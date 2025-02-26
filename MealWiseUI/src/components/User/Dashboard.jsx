import { logout, getUserIdFromToken } from "../../services/authService";
import apiService from "../../services/apiService";
import { useState, useEffect } from "react";
import { useNavigate } from 'react-router-dom';

const Dashboard = () => {
  const [userData, setUserData] = useState(null);
  const [error, setError] = useState(null);
  const userId = getUserIdFromToken();
  const navigate = useNavigate();
  
  useEffect(() => {
    const fetchUserData = async () => {
      if(!userId) 
        {
        setError("Bruger ikke logget ind.");
        return;
      }

      try {
        const data = await apiService.get(`users/${userId}`);
        setUserData(data);
      } catch (error) {
        setError("Kunne ikke hente brugerdata.");
      }
    };

  fetchUserData();
} , [userId]);

  const handleLogout = () => {
    logout();
    navigate("/login");
  };



  return (
    <div>
      <h2>Dashboard</h2>
      {error && <p style={{ color: "red" }}>{error}</p>}
      {userData ? <pre>{JSON.stringify(userData, null, 2)}</pre> : <p>Henter data...</p>}
      <button onClick={handleLogout}>Log ud</button>
    </div>
  );
};

export default Dashboard;
