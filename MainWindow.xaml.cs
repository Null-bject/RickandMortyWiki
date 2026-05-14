using RickAndMortyWiki.models;
using RickAndMortyWiki.services;
using RickAndMortyWiki.Wrappers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

namespace RickAndMortyWiki
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly Services _services;
        private CharacterWrapper characterSelected;

        public CharacterWrapper CharacterSelected
        {
            get { return characterSelected; }
            set
            {
                characterSelected = value;
                OnPropertyChanged();
                if (value == null) return;

            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<CharacterWrapper> Characters { get; set; } = [];
        public MainWindow()
        {
            InitializeComponent();
            _services = new Services();

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ChangeMode_Click(object sender, RoutedEventArgs e)
        {
            if (ColorBtn.Background is SolidColorBrush brush && brush.Color == Color.FromRgb(254, 247, 255))
            {
                WindowBck.Background = new SolidColorBrush(Color.FromRgb(10, 82, 106));
                ColorBtn.Background = new SolidColorBrush(Color.FromRgb(49, 47, 52));
                colorBtn.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                WindowBck.Background = new SolidColorBrush(Color.FromRgb(189, 216, 225));
                ColorBtn.Background = new SolidColorBrush(Color.FromRgb(254, 247, 255));
                colorBtn.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string search = txtSearch.Text;
                Characters.Clear();
                if (rbCharacter.IsChecked == true)
                {
                    dgResults.AutoGenerateColumns = false;

                    var result = await _services.GetCharacters(search);
                    //result.Results.ForEach(a => Characters.Add(
                    //    new CharacterWrapper()
                    //    {
                    //        Id = a.id,
                    //        Name = a.name,
                    //        Status = a.status
                    //    }))


                    foreach (var a in result.Results)
                    {
                        Characters.Add(new CharacterWrapper(a));
                    }
                    //dgResults.ItemsSource = result.Results;
                }

                if (rbEpisode.IsChecked == true)
                {
                    dgResults.AutoGenerateColumns = false;

                    var result = await _services.GetEpisodes(search);

                    dgResults.ItemsSource = result.Results;
                }

                if (rbLocation.IsChecked == true)
                {
                    dgResults.AutoGenerateColumns = false;

                    var result = await _services.GetLocation(search);

                    dgResults.ItemsSource = result.Results;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }

        }

        private void dgResults_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CharacterSelected == null) return;

            GridEditView.Visibility = Visibility.Visible;
        }

        private void BtnCloseEditView_Click(object sender, RoutedEventArgs e)
        {
            GridEditView.Visibility = Visibility.Hidden;


        }
    }
}