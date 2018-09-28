$(function () {  
    $('.usuarioCombo').hide();
});


function teste() {    
    $('#EhCasal').change(function () {
        if ($(this).is(':checked')) {            
            $('.usuarioCombo').hide();
        } else {
            $('.usuarioCombo').show();
        }
    });
}