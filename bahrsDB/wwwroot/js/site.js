/********************************************************************************/
/*Modal */
/********************************************************************************/
$('#formUpload').submit(function (e) {
    e.preventDefault(); // evita o refresh da pagina


    $('html, body').animate({ scrollTop: $("#box-progresso-upload").offset().top }, 600, null);
    $("#loader").show();

    $.ajax({
        url: this.action,
        type: this.method,
        data: new FormData(this),
        cache: false,
        contentType: false,
        processData: false,
        success: function (data) {
            let tipoModal;
            if (data.sucesso) {
                tipoModal = 'modal-success';
            } else {
                tipoModal = 'modal-danger';
            }
            showModal(tipoModal, data.mensagemRetorno);
            $("#loader").fadeOut();
        },
        error: function (xhr, error, status) {
            showModal('modal-danger', error + ' status: ' + status);
            $("#loader").fadeOut();
        }
    });
});


function showModal(tipoModal, textoModal) {

    //Limpando texto de msg anterior
    $("#texto-modal")
        .text("")
        .text(textoModal);



    //Limpando classes de retorno anterior e adicionando o retorno atual
    $("#janela-modal")
        .removeClass('modal-warning')
        .removeClass('modal-danger')
        .removeClass('modal-success')
        .addClass(tipoModal).modal('show');
}

var AJAXPortal = {

    POST(url, data, callback) {
        $.ajax({
            url: url,
            type: "POST",
            data: data,
            dataType: "json",
            beforeSend: function () {
                AJAXPortal.OpenLoad();
            },
            complete: function () {
                AJAXPortal.CloseLoad();
            },
            success: callback,
            error: function (xhr, exception) {
                AJAXPortal.CloseLoad();
                console.log("Erro: " + xhr.status + "  -  " + xhr.responseText);
            }
        });
    },

    POST2(url, target, data, callback) {
        $.ajax({
            url: url,
            type: "POST",
            data: data,

            beforeSend: function () {
                AJAXPortal.OpenLoad();
            },
            complete: function () {
                AJAXPortal.CloseLoad();
            },
            success: function (data) {
                $this = $("#" + target);
                $this.html(data);
                $('html, body').animate({ scrollTop: $this.offset().top }, 600, null);
                callback();
            },
            error: function (xhr, exception) {
                AJAXPortal.CloseLoad();
                console.log("Erro: " + xhr.status + "  -  " + xhr.responseText);
            }
        });
    },


    GET(url, target, callback) {
        $.ajax({
            url: url,
            type: "GET",
            beforeSend: function () {
                AJAXPortal.OpenLoad();
            },
            complete: function () {
                AJAXPortal.CloseLoad();
            },
            success: function (data) {
                $this = $("#" + target);
                $this.html(data);
                $('html, body').animate({ scrollTop: $this.offset().top }, 600, null);
                callback();
            },
            error: function (xhr, exception) {
                AJAXPortal.CloseLoad("Ocorreu um erro durante o processamento da requisição.");
                console.log("Erro: " + xhr.status + "  -  " + xhr.responseText + "  exception: " + exception);
            }
        });
    },

    ProgressoUpload(target) {
        $.get('/upload/progresso', function (data) {
            $(target).html(data);
        });
    },

    OpenLoad() {
        const gifRandom = Math.round((Math.random() * (10 - 1) + 1));
        $("#gifLoad").attr("src", `/images/gifs/${gifRandom}.gif`);
        $("#searching_Modal").modal('show');
    },

    CloseLoad(mensagem, tipoMensagem) {
        $("#searching_Modal").modal('hide');

        if (mensagem) {
            if (!tipoMensagem) {
                tipoMensagem = 'modal-danger';
            }
            showModal(tipoMensagem, mensagem);
        }
    }
};

var Modal = {

    Delete(Id, Descricao) {
        let url = (window.location.pathname.replace("Index", "") + '/Deletar').replace('//', '/');

        $("#formDelete").attr('action', url);
        $("#textoRegistro").text(Descricao);
        $("#idDelete").val(Id);
        $("#deleteModal").modal('show');
    },

    DeletePersonalizado(url, Id, Descricao) {

        $("#formDelete").attr('action', url);
        $("#textoRegistro").text(Descricao);
        $("#idDelete").val(Id);
        $("#deleteModal").modal('show');
    }
};

