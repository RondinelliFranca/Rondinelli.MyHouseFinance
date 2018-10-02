$(function () {  
    $('.usuarioCombo').hide();
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