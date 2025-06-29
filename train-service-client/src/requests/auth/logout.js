import config from "../../app/config.js";
import request from "../request.js";

async function logout() {
    const url = `${config.serverAddress}/api/v1/auth/logout`;

    return await request(url, "POST", 'include', {
        "Accept": "*/*"
    }, null, 200);
}

export default logout;