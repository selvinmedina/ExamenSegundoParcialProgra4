$("#btnEliminar").click(async function (e) {
    let dataFormulario = $("#frmEliminar").serializeArray();
    var esteBoton = this;
    console.log(dataFormulario);
    // Deshabilitar el boton actual
    await disabled(esteBoton, true);

    try {
        // Enviar la data
        await post(
            `${dataFormulario[0].value}`, // url
            dataFormulario, // Data del formulario
            async data => {
                window.location = "/MaestroExamen/Index";
            },
            async err => {
                alert("Datos invalidos");
            });

    } catch (error) {
        console.log(error);
    }
    await disabled(esteBoton, false);
});