import config from "../../../app/config.js";
import request from "../../request.js";

async function getTestPoints(testId) {
    const url =
        `${config.serverAddress}/api/v1/test-points/completion/by-test/${testId}`;

    return await request(url, "GET", 'include', {
        "Accept": "*/*"
    }, null, 200);
}

export default getTestPoints;