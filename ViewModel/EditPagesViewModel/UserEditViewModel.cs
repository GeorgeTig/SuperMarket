using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Models.Entity;
using ICommandDemoAgain.Commands;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SuperMarket.Models.BusinessLogicLayer;
using SuperMarket.Models.DataAccessLayer;

using System.Windows;

namespace SuperMarket.ViewModel.EditPagesViewModel
{
    public class UserEditViewModel : BaseViewModel
    {
        BusinessLogicLayer businessLogicLayer;
        public User user;
        public string _username;
        public string _usertype;
        public string _password;
        public string BText;
        string title;
        Visibility modify;
        
        public ICommand Button { get; set; }
        

        public UserEditViewModel()
        {
            businessLogicLayer = new BusinessLogicLayer();
            user = new User();
            _username = "";
            _usertype = "";
            _password = "";
            title = "Add User";
            BText = "Add";
            modify = Visibility.Visible;
            Button = new RelayCommand(o => Add());
           
        }

        public UserEditViewModel(User user)
        {
            businessLogicLayer = new BusinessLogicLayer();
            Button = new RelayCommand(o => Modify());
            this.user = user;
            _username = user.Username;
            BText = "Save";
            title = "Modify User";
            if (user.UserType == UserTypeEnum.Admin)
                _usertype = "Admin";
            else
                _usertype = "User";
            modify = Visibility.Hidden;
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public Visibility MODIFY
        {
            get { return modify; }
            set
            {
                modify = value;
                OnPropertyChanged("MODIFY");
            }
        }

        public string BTEXT
        {
            get { return BText; }
            set
            {
                BText = value;
                OnPropertyChanged("BTEXT");
            }
        }

        public string Name
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Name");
            }
        }

        public string Type
        {
            get { return _usertype; 
            }
            set
            {
                _usertype = value;
                OnPropertyChanged("Type");
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public void Add()
        {
            if (_username == "")
            {
                MessageBox.Show("introduceti un nume!");
                return;
            }

            if (_usertype.ToLower() != "admin" && _usertype.ToLower() != "user")
            {
                MessageBox.Show("introduceti in tip de utilizator 'admin' sau 'user' ");
                return;
            }

            if (businessLogicLayer.GetUser(_username) != null)
            {
                MessageBox.Show("user-ul deja exista!");
                return;
            }

           

            user.Username = _username;
            user.Password = _password;
            if (_usertype.ToLower() == "admin")
                user.UserType = UserTypeEnum.Admin;
            else
                user.UserType = UserTypeEnum.User;
            user.IsActive = true;
            businessLogicLayer.AddUser(user);

        }

        public void Modify()
        {
            if (_username == string.Empty)
            {
                MessageBox.Show("introduceti un nume!");
                return;
            }

            if (_usertype.ToLower() != "admin" && _usertype.ToLower() != "user")
            {
                MessageBox.Show("introduceti in tip de utilizator 'admin' sau 'user' ");
                return;
            }
            user.Username = _username;
            if (_usertype.ToLower() == "admin")
                user.UserType = UserTypeEnum.Admin;
            else
                user.UserType = UserTypeEnum.User;
            businessLogicLayer.UpdateUser(user);

        }

        


    }
}
