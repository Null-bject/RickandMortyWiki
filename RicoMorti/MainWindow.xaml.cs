using RicoMorti.Servicos;
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

namespace RicoMorti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Services rickMortyServices = new();
        private void Search()
        {
            _ = SearchAsync();
        }
        private async Task SearchAsync()
        {
            var list2 = await rickMortyServices.GetServices();

        }
        public MainWindow()
        {
            InitializeComponent();
            Search();
        }

        private void Episodes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Botão episodes");
        }
        private void Character_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Botão Character");
        }
        private void Location_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Botão Location");
        }
        private void ColorChanger_Click(object sender, RoutedEventArgs e)
        {
            if (colorBTN.BorderBrush is SolidColorBrush brush && brush.Color == Colors.Black)
            {
                this.Background = new SolidColorBrush(Color.FromRgb(3, 38, 58));
                colorBTN.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 165, 0));
                colorBTN.BorderBrush = new SolidColorBrush(Colors.White);
                CharBTN.Foreground = new SolidColorBrush(Colors.White);
                LocBTN.Foreground = new SolidColorBrush(Colors.White);
                EpiBTN.Foreground = new SolidColorBrush(Colors.White);


            }
            else
            {
                this.Background = new SolidColorBrush(Color.FromRgb(255,255,255));


            }
        }
    }
}