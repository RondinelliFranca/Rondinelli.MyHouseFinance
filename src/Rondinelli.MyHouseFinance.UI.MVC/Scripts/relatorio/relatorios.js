var myChart = null;

function destroyChart() {
    if (myChart != null) {
        myChart.destroy();
    }
}

function gerarGraficoPagamento() {
    destroyChart();
    if (validarDados()) {
        $.ajax({
            url: $("#IdUrlPorPagamento").val(),
            type: 'GET',
            data: {
                mesReferencia: mesReferencia.value,
                usuarioId: responsavelId.value
            },
            tryCount: 0,
            retryLimit: 3,
            success: function (json) {
                grafico(json, "bar", "Despesa por Usuario");
            },
            error: function () {
                toastr.error("Deu ruim");
            }
        });

    }
}

function gerarGrafico() {
    destroyChart();
    if (validarDados()) {

        $.ajax({
            url: $("#IdUrlPorDespesa").val(),
            type: 'GET',
            data: {
                mesReferencia: mesReferencia.value
            },
            tryCount: 0,
            retryLimit: 3,
            success: function (json) {
                grafico(json, "pie", "Grafico por despesas");
            },
            error: function () {
                toastr.error("Deu ruim");
            }
        });
    }
}

function gerarGraficoPagamentoPorPessoa() {
    debugger;
    destroyChart();
    if (validarGraficoPorPessoa()) {
        $.ajax({
            url: $("#IdUrlDoResponsavel").val(),
            type: 'GET',
            data: {
                mesReferencia: mesReferencia.value,
                usuarioId: responsavelId.value
            },
            tryCount: 0,
            retryLimit: 3,
            success: function (json) {
                grafico(json, "bar", "Grafico do responsável");
            },
            error: function () {
                toastr.error("Deu ruim");
            }
        });
    }
}

function validarDados() {

    if (mesReferencia.value === "") {
        toastr.info("Buscando de todos os meses!!");
        return true;
    }
    return true;
}

function grafico(data, typeChart, titleChart) {
    destroyChart();
    var ctx = document.getElementById("myChart");

    myChart = new Chart(ctx, {
        type: typeChart,
        data: {
            labels: data.Labels,
            datasets: [{
                label: titleChart,
                data: data.Valor,
                backgroundColor: [
                    '#B21212',
                    '#FFFC19',
                    '#0000FF',
                    '#088A08',
                    '#CC2EFA',
                    '#FF8000',
                    '#658248',
                    '#2EFE64',
                    '#848484',
                    '#FF0040',
                    '#08088A',
                    '#00FFFF',
                    '#8A4B08',
                    '#58FA58',
                    '#8A0886',
                    '#0B3B39'


                ],
                borderColor: [
                    '#000000'
                ],
                borderWidth: 2
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        suggestedMin: 50,
                        suggestedMax: 100,
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

function validarGraficoPorPessoa() {
    if (mesReferencia.value === "") {
        toastr.error("Preencher mês de referência.");
        return false;
    }

    if (responsavelId.value === "") {
        toastr.error("Preencher responsável");
        return false;
    }

    return true;
}