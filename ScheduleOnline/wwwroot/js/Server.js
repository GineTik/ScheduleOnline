export default class Server {
    static get(url, data) {
        return Server.call(url, data, "GET");
    }

    static post(url, data) {
        return Server.call(url, data, "POST");
    }

    static call(url, data, type) {
        let result = null;
        $.ajax({
            type: type,
            url: url,
            data: data,
            async: false,
            success: function (responce) {
                result = responce;
            },
            error: function (e) {
                throw new Error(url + " " + data + " " + type);
            }
        });
        return result;
    }
}