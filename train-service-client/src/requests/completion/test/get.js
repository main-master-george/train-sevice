import config from "../../../app/config.js";
import request from "../../request.js";

async function getTests(pageId, userId) {
    const url =
        `${config.serverAddress}/api/v1/test/completion/by-page/${pageId}?userId=${userId}`;

    return await request(url, "GET", 'include', {
        "Accept": "*/*"
    }, null, 200);
}

export default getTests;