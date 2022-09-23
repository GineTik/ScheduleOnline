export default class Server {
    static get(url, callback) {
        $.get(url)
            .done(callback)
            .fail(function () {
                alert("error");
            });
    }

    static post(url, callback) {
        $.post(url)
            .done(callback)
            .fail(function () {
                alert("error");
            });
    }
}