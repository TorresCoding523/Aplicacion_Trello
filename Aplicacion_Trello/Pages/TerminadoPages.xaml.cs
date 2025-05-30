using Aplicacion_Trello.Entidades;

namespace Aplicacion_Trello.Pages;

public partial class TerminadoPages : ContentPage
{
    public TerminadoPages()
    {
        InitializeComponent();
        CargarTareasTerminado();
    }

    private void CargarTareasTerminado()
    {
        try
        {
            // Obtener solo las tareas con estado "Terminado"
            List<Tareas> tareasTerminado = TareasCRUD.ObtenerTareasPorEstado("Terminado");

            // Diagnóstico: Imprimir las tareas obtenidas
            foreach (var tarea in tareasTerminado)
            {
                Console.WriteLine($"Tarea: {tarea.Titulo}, Estado: {tarea.Estado}");
            }

            // Asignar la lista filtrada al CollectionView
            lstTareas.ItemsSource = tareasTerminado;
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"No se pudieron cargar las tareas: {ex.Message}", "OK");
        }
    }
}
