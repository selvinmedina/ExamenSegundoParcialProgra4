$("#btnCrear").click(async function (e) {
    let dataFormulario = $("#frmCrear").serializeArray();
    var esteBoton = this;
    console.log(dataFormulario);
    // Deshabilitar el boton actual
    await disabled(esteBoton, true);

    try {
        // Enviar la data
        await post(
            `Create`, // url
            dataFormulario, // Data del formulario
            async data => {
                window.location = "Index";
            },
            async err => {
                alert("Datos invalidos");
            });

    } catch (error) {
        console.log(error);
    }
    await disabled(esteBoton, false);
});