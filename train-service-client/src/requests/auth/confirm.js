import config from "../../app/config.js";
import request from "../request.js";

async function confirmEmail(email) {
    const url = `${config.serverAddress}/api/v1/auth/confirm?email=${email}`;

    return await request(url, "POST", 'same-origin', {
        'Accept': '*/*'
    }, null, 200);
}

export default confirmEmail;