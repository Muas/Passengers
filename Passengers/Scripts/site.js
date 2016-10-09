$(document).ready(function () {
    moment.locale('ru');
    $('.selectpicker').selectpicker({
        style: 'btn-info',
        size: 4
    });
    $('.datetimepicker').datetimepicker({
        format: 'DD.MM.YYYY',
        minDate: '01.01.1900',
        maxDate: new Date()
    });

    $.validator.addMethod("ruLetters", function (value, element) {
        return this.optional(element) || /^[А-Я][а-я\-]*$/.test(value);
    }, 'Поле Имя должно содержать только буквы русского алфавита');

    $('.js-edit-passenger-form').validate({
        rules: {
            'name': {
                required: true,
                ruLetters: true
            }
        }
    });

});

