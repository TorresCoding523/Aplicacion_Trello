using Aplicacion_Trello.Entidades;

namespace Aplicacion_Trello.Pages;

public partial class HomePage1 : ContentPage
{
	public HomePage1()
	{
		InitializeComponent();
        CargarTareas();
    }
    private void CargarTareas()
    {
        try
        {
            List<Tareas> listaTareas = TareasCRUD.ObtenerTareas();
            lstTareas.ItemsSource = listaTareas; // ?? Asignar lista al ListView
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"No se pudieron cargar las tareas: {ex.Message}", "OK");
        }
    }

    private async void btnAgregarTarea_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetallesTareasPages());
    }

    private void PickerOrdenarTareas_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (pickerOrdenar.SelectedIndex != -1)
        {
            string criterioOrden = pickerOrdenar.SelectedItem.ToString();
            OrdenarTareas(criterioOrden);
        }
    }

    // M�todo para ordenar las tareas
    private void OrdenarTareas(string criterio)
    {
        List<Tareas> listaTareas = TareasCRUD.ObtenerTareas();

        switch (criterio)
        {
            case "Fecha de entrega":
                lstTareas.ItemsSource = listaTareas.OrderBy(t => t.Fecha_entrega).ToList();
                break;
            case "Fecha de asignaci�n":
                lstTareas.ItemsSource = listaTareas.OrderBy(t => t.Fecha_Asignacion).ToList();
                break;
            case "Nombre":
                lstTareas.ItemsSource = listaTareas.OrderBy(t => t.Titulo).ToList();
                break;
            case "Materia":
                lstTareas.ItemsSource = listaTareas.OrderBy(t => t.Materia).ToList();
                break;
        }
    }

    private async void EditButton_Clicked(object sender, EventArgs e)
    {
        // Obtener la tarea seleccionada desde el BindingContext
        Tareas tareaSeleccionada = (Tareas)((Button)sender).BindingContext;

        if (tareaSeleccionada != null)
        {
            await Navigation.PushAsync(new DetallesTareasPages(tareaSeleccionada));
        }
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // Obtener la tarea seleccionada desde el BindingContext
    Tareas tareaSeleccionada = (Tareas)((Button)sender).BindingContext;

    if (tareaSeleccionada != null)
    {
        // Confirmar si el usuario realmente desea eliminar la tarea
        bool confirmar = await DisplayAlert("Confirmar Eliminaci�n", "�Est�s seguro de que deseas eliminar esta tarea?", "S�", "No");

        if (confirmar)
        {
            // Llamar al m�todo para eliminar la tarea
            bool tareaEliminada = TareasCRUD.EliminarTarea(tareaSeleccionada.Id);

            if (tareaEliminada)
            {
                // Si la tarea se elimin� correctamente, mostrar mensaje y actualizar la lista de tareas
                DisplayAlert("�xito", "La tarea ha sido eliminada correctamente.", "OK");

                // Volver a cargar las tareas para reflejar los cambios
                CargarTareas();
            }
            else
            {
                // Si hubo un error al eliminar la tarea
                DisplayAlert("Error", "Hubo un problema al eliminar la tarea. Intenta nuevamente.", "OK");
            }
        }
    }
    }

    private async void OnTitleTapped(object sender, TappedEventArgs e)
    {
        // Llamamos a un m�todo para recargar los datos o refrescar la p�gina
        await RecargarPagina();
    }
    private async Task RecargarPagina()
    {
        // M�todo para refrescar o recargar datos, ejemplo recargar tareas
        CargarTareas();  // M�todo que carga las tareas en tu p�gina
    }
}