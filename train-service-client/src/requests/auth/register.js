import config from "../../app/config.js";
import request from "../request.js";

async function register(code, email, password) {
    const url = `${config.serverAddress}/api/v1/auth/users`;

    return await request(url, "POST", 'same-origin',{
            "Accept": "*/*",
            "Content-Type": "application/json"
        }, {
            code: code,
            email: email,
            password: password
        }, 200);
}

export default register;