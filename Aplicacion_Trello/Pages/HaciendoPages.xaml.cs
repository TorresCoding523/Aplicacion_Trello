using Aplicacion_Trello.Entidades;

namespace Aplicacion_Trello.Pages;

public partial class HaciendoPages : ContentPage
{
    public HaciendoPages()
    {
        InitializeComponent();
        CargarTareasHaciendo();
    }

    private void CargarTareasHaciendo()
    {
        try
        {
            // Obtener solo las tareas con estado "Haciendo"
            List<Tareas> tareasHaciendo = TareasCRUD.ObtenerTareasPorEstado("Haciendo");

            // Diagnóstico: Imprimir las tareas obtenidas
            foreach (var tarea in tareasHaciendo)
            {
                Console.WriteLine($"Tarea: {tarea.Titulo}, Estado: {tarea.Estado}");
            }

            // Asignar la lista filtrada al CollectionView
            lstTareas.ItemsSource = tareasHaciendo;
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"No se pudieron cargar las tareas: {ex.Message}", "OK");
        }
    }
}
