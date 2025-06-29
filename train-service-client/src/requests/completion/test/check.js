import config from "../../../app/config.js";
import request from "../../request.js";

async function check(userId, testId, correctPointId) {
    const url =
        `${config.serverAddress}/api/v1/test/completion`
            + `?userId=${userId}&testId=${testId}&correctPointId=${correctPointId}`;

    return await request(url, "POST", 'include', {
        "Accept": "*/*"
    }, null, 200);
}

export default check;