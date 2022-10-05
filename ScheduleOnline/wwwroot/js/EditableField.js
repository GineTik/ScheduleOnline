export default class EditableField {
    constructor($field, callback) {
        this.setField($field);
        this.setEvents(callback);
    }

    setField($field) {
        this.$field = $field;
        this.$field.attr("contentEditable", "true");
    }

    setEvents(callback) {
        this.$field.blur(callback);
        this.$field.keydown(function(e) {
            if (e.keyCode === 13) {
                e.preventDefault();
                $(this).blur();
            }
        });
    }
}