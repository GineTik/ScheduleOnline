import Server from "./Server.js";

export default class ScheduleManager {
    changeTitle(id, title) {
        Server.post("/Schedule/ChangeTitle", { id: id, title: title });
    }
}