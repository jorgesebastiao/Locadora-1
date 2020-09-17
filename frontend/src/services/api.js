import axios from 'axios';

let apiAddress = '';

if (process.env.NODE_ENV === 'production') {
    apiAddress = 'https://locadorawebapp.azurewebsites.net';
} else {
    apiAddress = 'http://localhost:5000';
}

const api = axios.create({
    baseURL: apiAddress,
})

export default api;