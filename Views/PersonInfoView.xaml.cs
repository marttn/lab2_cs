using System.Windows.Controls;
using lab2_cs.Tools.Navigation;
using lab2_cs.ViewModels;

namespace lab2_cs.Views
{
    public partial class PersonInfoView : UserControl,INavigatable
    {
        internal PersonInfoView()
        {
            InitializeComponent();
            DataContext = new PersonInfoViewModel();
        }
    }
}
