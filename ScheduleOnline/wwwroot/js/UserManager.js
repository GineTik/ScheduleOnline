import Server from "./Server.js";

export default class UserManager {
    resetFind() {
        window.location.href = "/Admin";
    }

    find(email) {
        if (email != "") {
            window.location.href = "/Admin/Find?email=" + email;
        } else {
            this.resetFind();
        }
    }

    delete(id, buttonWrapper) {
        Server.post("/User/RemoveUser/" + id, () => {
            buttonWrapper.html($("<div class='btn btn-secondary btn-restore' data-id='${id}'>відновити</div>"));
        });
    }

    restore(id, buttonWrapper) {
        Server.post("/User/RestoreUser/" + id, () => {
            buttonWrapper.html($("<div class='btn btn-secondary btn-remove' data-id='${id}'>видалити</div>"));
        });
    }
}