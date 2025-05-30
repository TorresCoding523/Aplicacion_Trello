using Aplicacion_Trello.Entidades;

namespace Aplicacion_Trello.Pages;

public partial class ConRetrasoPages : ContentPage
{
    public ConRetrasoPages()
    {
        InitializeComponent();
        CargarTareasConRetraso();
    }

    private void CargarTareasConRetraso()
    {
        try
        {
            // Obtener solo las tareas con estado "Con retraso"
            List<Tareas> tareasConRetraso = TareasCRUD.ObtenerTareasPorEstado("Con retraso");

            // Diagnóstico: Verificar si se han encontrado tareas
            if (tareasConRetraso.Count == 0)
            {
                DisplayAlert("Aviso", "No se encontraron tareas con retraso", "OK");
            }

            // Asignar la lista filtrada al CollectionView
            lstTareas.ItemsSource = tareasConRetraso;
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"No se pudieron cargar las tareas: {ex.Message}", "OK");
        }
    }
}
