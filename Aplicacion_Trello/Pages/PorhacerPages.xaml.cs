using Aplicacion_Trello.Entidades;

namespace Aplicacion_Trello.Pages;

public partial class PorhacerPages : ContentPage
{
    public PorhacerPages()
    {
        InitializeComponent();
        CargarTareasPorHacer();
    }

    private void CargarTareasPorHacer()
    {
        try
        {
            // Obtener solo las tareas con estado "Por hacer"
            List<Tareas> tareasPorHacer = TareasCRUD.ObtenerTareasPorEstado("Por hacer");

            // Diagnóstico: Imprimir las tareas obtenidas
            foreach (var tarea in tareasPorHacer)
            {
                Console.WriteLine($"Tarea: {tarea.Titulo}, Estado: {tarea.Estado}");
            }

            // Asignar la lista filtrada al CollectionView
            lstTareas.ItemsSource = tareasPorHacer;
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"No se pudieron cargar las tareas: {ex.Message}", "OK");
        }
    }
}
