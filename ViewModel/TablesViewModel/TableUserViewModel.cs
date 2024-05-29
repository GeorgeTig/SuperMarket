using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Models.Entity;
using SuperMarket.Models.DataAccessLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ICommandDemoAgain.Commands;
using SuperMarket.View;
using System.Windows.Controls;
using SuperMarket.View.EditPages;

namespace SuperMarket.ViewModel
{
    public class TableUserViewModel : BaseViewModel
    {
        public List<User> Users { get; set; }
        public BusinessLogicLayer BusinessLogicLayer { get; set; }
        public ICommand AddUserCommand { get; set; }
        public ICommand ModifyUserCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }

        public object SelectedItem { get; set; } = null;

        public TableUserViewModel()
        {
            Users = new List<User>();
            BusinessLogicLayer = new BusinessLogicLayer();
            Users= BusinessLogicLayer.GetAllUsers();
            
            

            AddUserCommand = new RelayCommand((o) =>
            {
                if (o is not Page page)
                {
                    return;
                }

                page.NavigationService.Navigate(new EditUserPage());
            });

            ModifyUserCommand = new RelayCommand((o) =>
            {
                if (o is not Page page)
                {
                    return;
                }
                if (SelectedItem == null)
                {
                    return;
                }
                page.NavigationService.Navigate(new EditUserPage(SelectedItem as User));
            });

            DeleteUserCommand = new RelayCommand((o) =>
            {
                
                if (SelectedItem == null)
                {
                    return;
                }
                User user = SelectedItem as User;
                BusinessLogicLayer.DeleteUser(user.UserId);
                Users.Remove(user);
            });
        }

        public List<User> USERS
        {
            get { return Users; }
            set
            {
                Users = value;
                OnPropertyChanged("USERS");
            }
        }
    }
}
