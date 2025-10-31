function generarPDFPedidos(titulo, columnas, filas) {
    // Inicializar jsPDF
    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    // Agregar el título
    doc.text(titulo, 14, 20);

    // Generar la tabla
    doc.autoTable({
        head: [columnas], // Los encabezados de la tabla
        body: filas,      // Los datos (filas) de la tabla
        startY: 25        // Dónde empezar a dibujar la tabla
    });

    // Guardar el archivo PDF
    doc.save('reporte_pedidos.pdf');
}