export default class EditableField {
    constructor($field, callback) {
        this.setField($field);
        this.setUnfocusCallback(callback);
        this.setEvents();
    }

    setField($field) {
        this.$field = $field;
        this.$field.attr("contentEditable", "true");
    }

    setEvents() {
        this.$field.blur(this.callback);
        this.$field.keydown((e) => {
            if (e.keyCode === 13) {
                e.preventDefault();
                this.$field.blur();
            }
        });
    }

    setUnfocusCallback(callback) {
        this.callback = callback;
    }
}