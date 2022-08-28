import Base from "./BaseService.js";

export class LessonService extends Base {
    add(addButton, dayId) {
        $.post(this.getPath("Lesson", "Add"), { dayId: dayId }, function (response) {
            console.log(response);

            response = {
                name: "новый урок",
                time: {
                    from: "10:00",
                    to: "11:20"
                }
            }

            addButton.insertAdjacentHTML('beforeBegin', `
                <tr class="table__row">
                    <td class="table__col">
                        <span class="table__editable-field editable-field" contenteditable>${response.name}</span>
                        <ion-icon class="btn-icon table__trash" name="trash-sharp"></ion-icon>
                    </td>
                    <td class="table__col">
                        з <span class="table__editable-field editable-field">${response.time.from}</span>
                        до <span class="table__editable-field editable-field">${response.time.to}</span>
                    </td>
                </tr>
            `);
        });
    }
}