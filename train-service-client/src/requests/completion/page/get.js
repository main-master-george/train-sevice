import config from "../../../app/config.js";
import request from "../../request.js";

async function get(moduleId) {
    const url =
        `${config.serverAddress}/api/v1/pages/completion/by-module/${moduleId}`;

    return await request(url, "GET", 'include', {
        "Accept": "*/*",
    }, null, 200);
}

export default get;