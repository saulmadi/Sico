$.fn.CreateDialogWindow = function (botonDisparador, dialogo, mensajeAceptado, nombreFormulario) {
    $('.' + botonDisparador).button();

    $('#' + dialogo).dialog({
        autoOpen: false,
        resizable: false,
        width:"450",
        modal: true,
        show: "drop",
        hide: "drop",
        buttons: {
            "Guardar": function () {
                $("#" + mensajeAceptado).html(''); //make sure there is nothing on the message before we continue                         
                $("#" + nombreFormulario).submit();

            },
            "Cancelar": function () {
                $(this).dialog("close");
            }
        }
    });

    $('.' + botonDisparador).click(function () {
        //change the title of the dialgo

        var linkObj = $(this);
        var dialogDiv = $('#' + dialogo);
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#" + nombreFormulario);
            // Unbind existing validation
            $form.unbind();
            $form.data("validator", null);
            // Check document for changes
            $.validator.unobtrusive.parse(document);
            // Re add validation with changes
            $form.validate($form.data("unobtrusiveValidation").options);
            //open dialog
            dialogDiv.dialog('open');
        });
        return false;
    });

};