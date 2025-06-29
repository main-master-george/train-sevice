import config from "../../../app/config.js";
import request from "../../request.js";

async function getText(pageId) {
    const url =
        `${config.serverAddress}/api/v1/texts/completion/by-page/${pageId}`;

    return await request(url, "GET", 'include', {
        "Accept": "*/*"
    }, null, 200);
}

export default getText;