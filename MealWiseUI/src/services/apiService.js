import axios from "axios";
import { getToken } from "./authService";

const API_URL = "https://localhost:7104/api"; // Opdater din backend-URL

const apiService = {
  get: async (endpoint) => {
    try {
      const response = await axios.get(`${API_URL}/${endpoint}`, {
        headers: { Authorization: `Bearer ${getToken()}` },
      });
      return response.data;
    } catch (error) {
      console.error(`Fejl ved GET ${endpoint}:`, error.response?.data || error.message);
      throw error;
    }
  },

  post: async (endpoint, data) => {
    try {
      const response = await axios.post(`${API_URL}/${endpoint}`, data, {
        headers: { Authorization: `Bearer ${getToken()}` },
      });
      return response.data;
    } catch (error) {
      console.error(`Fejl ved POST ${endpoint}:`, error.response?.data || error.message);
      throw error;
    }
  },

  put: async (endpoint, data) => {
    try {
      const response = await axios.put(`${API_URL}/${endpoint}`, data, {
        headers: { Authorization: `Bearer ${getToken()}` },
      });
      return response.data;
    } catch (error) {
      console.error(`Fejl ved PUT ${endpoint}:`, error.response?.data || error.message);
      throw error;
    }
  },

  delete: async (endpoint) => {
    try {
      const response = await axios.delete(`${API_URL}/${endpoint}`, {
        headers: { Authorization: `Bearer ${getToken()}` },
      });
      return response.data;
    } catch (error) {
      console.error(`Fejl ved DELETE ${endpoint}:`, error.response?.data || error.message);
      throw error;
    }
  },
};

export default apiService;
