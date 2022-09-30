import Server from "../../Server.js";

export default class DayManager {
    create(scheduleId) {
        return Server.post("/Day/Create", { scheduleId: scheduleId });
    }
}