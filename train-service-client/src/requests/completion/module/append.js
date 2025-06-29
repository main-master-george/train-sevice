import config from "../../../app/config.js";
import request from "../../request.js";

async function append(userId, moduleIds) {
    const url =
        `${config.serverAddress}/api/v1/modules/completion?userId=${userId}`;

    return await request(url, "POST", 'include', {
        "Accept": "*/*",
        "Content-Type": "application/json"
    }, moduleIds, 200);
}

export default append;