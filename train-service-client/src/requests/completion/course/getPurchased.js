import config from "../../../app/config.js";
import request from "../../request.js";

async function getPurchased(userId, page, pageSize) {
    const url =
        `${config.serverAddress}/api/v1/courses/completion/${userId}/purchased?page=${page}&pageSize=${pageSize}`;

    return await request(url, "GET", 'include', {
        "Accept": "*/*"
    }, null, 200);
}

export default getPurchased;