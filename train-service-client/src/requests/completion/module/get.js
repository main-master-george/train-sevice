import config from "../../../app/config.js";
import request from "../../request.js";

async function get(courseId, userId) {
    const url =
        `${config.serverAddress}/api/v1/modules/completion/${courseId}?userId=${userId}`;

    return await request(url, "GET", 'include', {
        "Accept": "*/*",
    }, null, 200);
}

export default get;