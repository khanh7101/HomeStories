import axios from "axios";

const apiClient = axios.create({
  baseURL: "https://localhost:7222/api", // URL của BE .NET
  headers: {
    "Content-Type": "application/json"
  }
});

export default apiClient;
