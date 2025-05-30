using Aplicacion_Trello.Conexion;
using MySql.Data.MySqlClient;
namespace Aplicacion_Trello.Pages;

public partial class HomePages : ContentPage
{
	public HomePages()
	{
		InitializeComponent();
	}
    private async void OnCheckConnectionClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HomePage1());

        ConnectionStatusLabel.Text = "Checking connection...";
        ConnectionStatusLabel.TextColor = Colors.Gray;

        var result = await Task.Run(() => MySQLWorkbench.CheckConnection());

        if (result.isConnected)
        {
            ConnectionStatusLabel.Text = "Connection successful!";
            ConnectionStatusLabel.TextColor = Colors.Green;
        }
        else
        {
            ConnectionStatusLabel.Text = $"Connection failed: {result.message}";
            ConnectionStatusLabel.TextColor = Colors.Red;
        }
    

    /*private (bool isConnected, string message) CheckMySqlConnection()
    {
        // Replace with your actual connection string
        //string connectionString = "Server=localhost;UserId=root;Password=21021192;Port=3306;Database=ClassroomDB;";
        string connectionString = "Server=10.0.2.2;UserId=root1;Password=21021192;Port=3306;Database=devart_test;";



        try
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                return (true, "Connection successful!");
            }
        }
        catch (MySqlException ex)
        {
            // MySQL specific errors (authentication, connection, etc.)
            return (false, $"MySQL error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // General exceptions (network, unknown issues)
            return (false, $"General error: {ex.Message}");
        }*/
    }
}