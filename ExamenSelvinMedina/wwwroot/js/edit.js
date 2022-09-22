$("#btnEditar").click(async function (e) {
    let dataFormulario = $("#frmEditar").serializeArray();
    var esteBoton = this;
    console.log(dataFormulario);
    // Deshabilitar el boton actual
    await disabled(esteBoton, true);

    try {
        // Enviar la data
        await post(
            `?id=${dataFormulario[0]}`, // url
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