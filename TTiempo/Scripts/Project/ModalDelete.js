
    $('.eliminar').click(function () {
            var idEliminar = $(this).attr("data-id");
            $("#btnEliminar").attr("data-eliminar", idEliminar);
            window.$("#myModal").modal();
        });
        $("#btnEliminar").click(function () {
            var idEliminar = $(this).attr("data-eliminar");
            $.ajax({
        url: '/Customer/Delete/',
                type: 'get',
                data: {id: idEliminar },
                dataType: 'json',
                success: function (result) {
        console.log("Exito");
                    $("#" + idEliminar).remove();
                    $("#myModal").modal('hide');
                    $(location).attr('href', "/");
                },
                error: function () {
        console.log("fallo");
                }
            });
        });