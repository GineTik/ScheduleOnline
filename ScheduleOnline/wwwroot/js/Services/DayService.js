import BaseService from "./BaseService.js";

export class DayService extends BaseService {
    add(scheduleId) {
        $.post(this.getPath("Day", "Add"), {}, function (response) {
            console.log(response);
        });
    }
}