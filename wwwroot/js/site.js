$(document).ready(function () {
    $('#btnSalvar').on('click', function () {

        let cliente = $('#txtCliente').val();
        let Data = $('#txtData').val();
        let Vendedor = $('#txtVendedor').val();
        let Descricao = $('#txtDescricao').val();
        let Valor = $('#txtValor').val();
        $.ajax({
            url: "/home/cadastrarOrcamento",
            data: {
                'NomeCliente': cliente, 'DataOrcamento': Data, 'Vendedor': Vendedor, 'DescricaoOrcamento': Descricao, 'ValorOrcado': Valor},
            type:'POST'
        })
            .done(function (data) {
                alert("Cadastrado com sucesso");
            });
    });



    $("#txtFiltro").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#tabela tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    


});

function deletar(x) {

    $.ajax({
        url: "/home/deletarOrcamento/?codorcamento=" + x,

        type: 'GET'
    })
        .done(function (data) {
            window.location.href = "/home/Consulta";
        });
}
