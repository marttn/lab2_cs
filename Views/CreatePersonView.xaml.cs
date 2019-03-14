using System.Windows.Controls;
using lab2_cs.Tools.Navigation;
using lab2_cs.ViewModels;

namespace lab2_cs.Views
{
    public partial class CreatePersonView : UserControl, INavigatable
    {
        internal CreatePersonView()
        {
            InitializeComponent();
            DataContext = new CreatePersonViewModel();
        }
    }
}
