import config from "../../app/config.js";
import request from "../request.js";

async function login(email, password) {
    const url = `${config.serverAddress}/api/v1/auth/login`;

    return await request(url, "POST", 'include', {
        "Accept": "*/*",
        "Content-Type": "application/json"
    }, {
        email: email,
        password: password
    }, 200);
}

export default login;