export default class Server {
    static get(url, data) {
        return Server.send(url, data, "GET");
    }

    static post(url, data) {
        return Server.send(url, data, "POST");
    }

    static send(url, data, type) {
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