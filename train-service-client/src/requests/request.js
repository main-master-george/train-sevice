import ApiResponse from "./ApiResponse.js";

async function request(url, method, credentials, headers, body, status) {
    const options = {
        method: method,
        credentials: credentials,
        headers: headers
    };

    if (body && method !== 'GET') {
        options.body = JSON.stringify(body);
    }

    try {
        const response = await fetch(url, options);

        if (response.status !== status) {
            return new ApiResponse(false, `Ошибка при выполнении запроса`);
        }

        const data = await response.json();
        return new ApiResponse(true, 'Успешный ответ', data);
    } catch (error) {
        return new ApiResponse(false, `Ошибка при выполнении запроса: ${error.message}`);
    }
}

export default request;