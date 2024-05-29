using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.ViewModel;
using SuperMarket.Models.BusinessLogicLayer;
using Supermarket;
using ICommandDemoAgain.Commands;
using System.Windows.Input;
using System.Windows;
using SuperMarket.Models.Entity;
using System.Windows.Navigation;
using System.Windows.Controls;
using SuperMarket.Models.DataAccessLayer;
using SuperMarket.View;



namespace SuperMarket.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public BusinessLogicLayer businessLogicLayer { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand UserVerification { get; set; }
        
        public LoginViewModel()
        {
            businessLogicLayer = new BusinessLogicLayer();
            UserVerification = new RelayCommand(o => VerifyUser(o));

        }

        private void VerifyUser(object o )
        {

            if(o is not Page page)
            {
                return;
            }
            if(Username=="" || Password == "" || Username==null || Password==null)
            {
                MessageBox.Show("Please enter username and password");
                return;
            }
            
            UserBLL userBLL = new UserBLL();
            if (businessLogicLayer.UserValidation(Username,Password).UserType == UserTypeEnum.Admin)
            {
                
                page.NavigationService.Navigate(new AdminPage());
               

            }

            if (businessLogicLayer.UserValidation(Username, Password).UserType == UserTypeEnum.User)
            {
               User user = businessLogicLayer.GetUser(Username);
                page.NavigationService.Navigate(new UserPage(user));


            }



        }
    }
}
