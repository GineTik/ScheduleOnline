export default class DayRenderer {
    render($container, day) {
        $container.append(`
            <table class="day table">
                <tr class="table__title">
                    <td class="table__col" colspan="2">
                        <div class="table__editable-field editable-field">${day.title}</div>
                        <ion-icon class="btn-icon table__trash" name="trash-sharp" data-delete-id="${day.id}"></ion-icon>
                    </td>
                </tr>
                <tr class="table__row">
                    <td class="table__col table__btn btn" colspan="2">
                        додати новий рядок
                    </td>
                </tr>
            </table>
        `);
    }
}