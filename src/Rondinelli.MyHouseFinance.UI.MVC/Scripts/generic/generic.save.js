$(function () {  
    masking();
    CarregarData();
    CarregarSelect();
    //applySumoSelect();    
});

function masking() {
    applyMaskYear();
    applyMaskOrder();
    applyMaskPhone();
    applyMaskWeight();
    applyMaskFloat();
    applyMaskCNPJ();
}

function CarregarSelect() {
    $('.comboboxS2').select2();
}

function CarregarData() {   
    $(".dataTPicker").datetimepicker({
        locale: "pt-br",
        format: "DD/MM/YYYY"
    });

    $(".dataMesPicker").datetimepicker({
        locale: "pt-br",
        format: "MM/YYYY"
    });
    
    $('.dataPickerMask').mask('00/00/0000');
    
}

function applyMaskPhone() {        
    var maskBehavior = function (val) {
        return val.replace(/\D/g, "").length === 11 ? "(00) 00000-0000" : "(00) 0000-00009";
    },
spOptions = {
    onKeyPress: function (val, e, field, options) {
        field.mask(maskBehavior.apply({}, arguments), options);
    }
};

    $(".maskPhone").mask(maskBehavior, spOptions);
    
}

function applyMaskWeight() {
    $(".maskWeight").mask("9,99");   
}

function applyMaskFloat() {
    $(".maskFloat").mask("999999999999999999,99", { placeholder : "0,00"});
}

function applyMaskOrder() {    
    $(".maskOrder").mask("99");    
}

function applyMaskYear() {
    $(".maskYear").mask("9999");
}

function applyMaskMoney() {
    $('.money').mask('000.000.000.000.000,00', { reverse: true });
    $('.money2').mask("#.##0,00", { reverse: true });
}

function applyMaskCNPJ() {
    $(".maskCNPJ").mask("99.999.999/9999-99");
}

function applySumoSelect() {
    try {
        $(".ddlSumo").SumoSelect();
        buildSumoMultiSelect("#ddlApplicationId");
        buildSumoMultiSelect("#ddlPermissionId");
    }
    catch (e) {
        if (e instanceof TypeError) {
            // ignore TypeError: $(...).SumoSelect is not a function
        }
        else {
            throw e;
        }
    }
}