$(document).ready(function() {
    $('.selectpicker').selectpicker({
        style: 'btn-info',
        size: 4
    });

    $('.datetimepicker').datetimepicker({
        format: 'DD.MM.YYYY',
        minDate: '01.01.1900',
        useCurrent : true,
        locale: 'ru',
        showClose: true
    });

    $.validator.addMethod("ruLetters", function(value, element) {
        return this.optional(element) || /^[А-Я][а-я\-]*$/.test(value);
    }, 'Поле Имя должно содержать только буквы русского алфавита');

    $.validator.addMethod("passengerTypeRequired", function(value, element) {
        return this.optional(element) || value;
    }, 'Поле Тип пассажира должно быть задано');

    $.validator.addMethod("validTypeForDate", function(value, element) {
        var now = new Date();
        var min = $('#PassengerType').data('min');
        var max = $('#PassengerType').data('max');
        var birthDate = moment($('#BirthDate').val(), 'DD.MM.YYYY');
        return birthDate.add(max, 'y') <= now || birthDate.add(min, 'y') >= now;
    }, 'Выбранный тип пассажира не соответствует возрасту пассажира');

    $.validator.methods.date = function (value, element) { return true; }
   
    $('.js-edit-passenger-form').validate({
        rules: {
            'Name': {
                required: true,
                ruLetters: true
            },
            'PassengerType': {
                passengerTypeRequired: true,
                validTypeForDate: true
            }
        }
    });

});

