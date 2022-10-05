import Server from "../../Server.js";

export default class DayManager {
    create(scheduleId) {
        return Server.post("/Day/Create", { scheduleId: scheduleId });
    }

    remove(dayId) {
        return Server.post("/Day/Remove", { dayId: dayId });
    }

    changeTitle(dayId, title) {
        return Server.post("/Day/ChangeTitle", { id: dayId, title: title });
    }
}