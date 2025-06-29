import config from "../../../app/config.js";
import request from "../../request.js";

async function append(courseId, userId) {
    const url =
        `${config.serverAddress}/api/v1/courses/completion/append?courseId=${courseId}&userId=${userId}`;

    return await request(url, "POST", 'include', {
        "Accept": "*/*"
    }, null, 200);
}

export default append;