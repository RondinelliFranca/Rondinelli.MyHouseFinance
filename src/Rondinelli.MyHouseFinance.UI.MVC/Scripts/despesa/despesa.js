
$(document).ready(function () {
    $('.usuarioCombo').hide();
    $('.usuariosCombo').hide();
    $('.multiple2').select2();

});


function HabilitarPagador() {
    $('#EhCasal').change(function () {
        if ($(this).is(':checked')) {
            $('.usuarioCombo').hide();
        } else {
            $('.usuarioCombo').show();
        }
    });
}


function HabilitarPagadores() {
    $('#EhDivisao').change(function () {
        if ($(this).is(':checked')) {
            $('.usuariosCombo').show();
            $('.usuarioCombo').hide();
        } else {
            $('.usuariosCombo').hide();
            $('.usuarioCombo').show();
        }
    });
}