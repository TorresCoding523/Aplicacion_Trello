using Aplicacion_Trello.Entidades;

namespace Aplicacion_Trello.Pages;

public partial class DetallesTareasPages : ContentPage
{
    private Tareas tareaActual;
    public DetallesTareasPages()
	{
		InitializeComponent();
	}

    // Constructor para editar una tarea existente (con un parámetro de tipo Tareas)
    public DetallesTareasPages(Tareas tarea)
    {
        InitializeComponent();
        tareaActual = tarea;

        // Llenar los controles con los datos de la tarea
        entryTitulo.Text = tarea.Titulo;
        entryMateria.Text = tarea.Materia;
        editorDescripcion.Text = tarea.Descripcion;
        datePickerAsignacion.Date = tarea.Fecha_Asignacion;
        datePickerEntrega.Date = tarea.Fecha_entrega;
        pickerEstado.SelectedItem = tarea.Estado;
    }

    private void bntGuardar_Clicked(object sender, EventArgs e)
    {
        // Crear un objeto Tareas con los datos del formulario
        Tareas nuevaTarea = new Tareas
        {
            Titulo = entryTitulo.Text,               // Asume que 'entryTitulo' es el Entry del título
            Materia = entryMateria.Text,             // Asume que 'entryMateria' es el Entry de la materia
            Descripcion = editorDescripcion.Text,    // Asume que 'editorDescripcion' es el Editor de descripción
            Fecha_Asignacion = datePickerAsignacion.Date,  // Asume que 'datePickerAsignacion' es el DatePicker de fecha de asignación
            Fecha_entrega = datePickerEntrega.Date,      // Asume que 'datePickerEntrega' es el DatePicker de fecha de entrega
            Estado = pickerEstado.SelectedItem.ToString()   // Asume que 'pickerEstado' es el Picker de estado
        };

        // Llamar al método para insertar la tarea en la base de datos
        bool tareaInsertada = TareasCRUD.InsertarTarea(nuevaTarea);

        if (tareaInsertada)
        {
            DisplayAlert("Éxito", "La tarea se ha guardado correctamente.", "OK");
            // Limpiar los campos del formulario
            LimpiarFormulario();
        }
        else
        {
            DisplayAlert("Error", "Hubo un problema al guardar la tarea. Intenta nuevamente.", "OK");
        }
    }
    // Método para limpiar los campos del formulario después de guardar la tarea
    private void LimpiarFormulario()
    {
        entryTitulo.Text = string.Empty;
        entryMateria.Text = string.Empty;
        editorDescripcion.Text = string.Empty;
        datePickerAsignacion.Date = DateTime.Now;
        datePickerEntrega.Date = DateTime.Now;
        pickerEstado.SelectedItem = null;
    }
}