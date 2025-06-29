import config from "../../../app/config.js";
import request from "../../request.js";

async function getNotPurchased(userId, page, pageSize) {
    const url =
        `${config.serverAddress}/api/v1/courses/completion/${userId}/not-purchased?page=${page}&pageSize=${pageSize}`;

    return await request(url, "GET", 'include', {
        "Accept": "*/*"
    }, null, 200);
}

export default getNotPurchased;