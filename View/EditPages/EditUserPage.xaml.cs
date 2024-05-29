using SuperMarket.Models.Entity;
using SuperMarket.ViewModel.EditPagesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperMarket.View.EditPages
{
    /// <summary>
    /// Interaction logic for EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        public EditUserPage()
        {
            InitializeComponent();
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            this.DataContext = userEditViewModel;
        }
        public EditUserPage(User user)
        {
            InitializeComponent();
            UserEditViewModel userEditViewModel = new UserEditViewModel(user);
            this.DataContext = userEditViewModel;
        }
    }
}
