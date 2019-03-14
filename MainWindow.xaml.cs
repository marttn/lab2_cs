using System.Windows;
using System.Windows.Controls;
using lab2_cs.Tools.Managers;
using lab2_cs.Tools.Navigation;
using lab2_cs.ViewModels;

namespace lab2_cs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IContentOwner
    {
        public ContentControl ContentControl {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.CreatePerson);
        }

    }
}
