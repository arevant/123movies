import axios from 'axios';

const apiUrl = process.env.REACT_APP_API_URL;

axios.defaults.headers = {
    "Access-Control-Allow-Origin": "*",
    "content-type": "application/json",
}

export const authenticate = (username: string, password: string) => {
    return axios.post(`${apiUrl}api/users/login`, { username, password });
}