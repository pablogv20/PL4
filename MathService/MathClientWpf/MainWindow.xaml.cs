using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathClientWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e) // Cambiar a método async
        {
            // Convierte el contenido de campo de texto a Int32
            if (Int32.TryParse(tbx_Numero.Text, out int iValue))
            {
                try
                {
                    // Se instancia el proxy
                    MathService.MathClient client = new MathService.MathClient();

                    // Se invoca el servicio
                    bool result = await client.PrimeAsync(iValue); // Usar el método PrimeAsync

                    lbl_Resultado.Content = result;
                }
                catch (Exception ex)
                {
                    // Manejar la excepción (por ejemplo, mostrar un mensaje de error)
                    MessageBox.Show($"Error al invocar el servicio: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El valor ingresado no es un número entero válido.");
            }
        }
    }
}