import axios from 'axios';

const token = localStorage.getItem("authtoken");
const bearer = "Bearer " + token;
const apiUrl = process.env.REACT_APP_API_URL;

axios.defaults.headers = {
  "Access-Control-Allow-Origin": "*",
  "Authorization": bearer,
  "content-type": "application/json",
}

export const getAll = async () => {
  return await axios.get(`${apiUrl}api/movies/all`);
};