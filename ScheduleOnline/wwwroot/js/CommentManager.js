import Server from "./Server.js"

export default class CommentManager {
    switchCommentsState(scheduleId) {
        return Server.post("/Comment/SwitchCommentsState", { scheduleId: scheduleId });
    }
}