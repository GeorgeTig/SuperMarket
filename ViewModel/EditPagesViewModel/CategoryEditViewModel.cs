using ICommandDemoAgain.Commands;
using Microsoft.EntityFrameworkCore.Metadata;
using SuperMarket.Models.DataAccessLayer;
using SuperMarket.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SuperMarket.ViewModel.EditPagesViewModel
{
    public class CategoryEditViewModel : BaseViewModel
    {
        BusinessLogicLayer businessLogicLayer;
        public Category category;
        public string _categoryname;
        public ICommand Button { get; set; }
        public string modify;
        public string Title { get; set; }

        public CategoryEditViewModel()
        {
            businessLogicLayer = new BusinessLogicLayer();
            category = new Category();
            _categoryname = "";
            Button = new RelayCommand(o => Add());
            modify = "Add";
            Title = "Add Category";
        }

        public CategoryEditViewModel(Category category)
        {
            businessLogicLayer = new BusinessLogicLayer();
            this.category = category;
            _categoryname = category.Name;
            Button = new RelayCommand(o => Modify());
            modify = "Save";
            Title = "Modify Category";
        }

        public string Name
        {
            get { return _categoryname; }
            set { _categoryname = value;
                OnPropertyChanged("Name");
            }
        }

        public string MODIFY
        {
            get { return modify; }
            set { modify = value;
                OnPropertyChanged("MODIFY");
            }
        }

        public void Add()
        {
            category.Name = _categoryname;
            if (category.Name == "")
            {
                MessageBox.Show("Numele categoriei nu poate fi gol!");
                return;
            }
            if (businessLogicLayer.GetCategory(category.Name) != null)
            {
                MessageBox.Show("Aceasta categorie exista deja!");
                return;
            }
            
            businessLogicLayer.AddCategory(category.Name);
        }

        public void Modify()
        {
            category.Name = _categoryname;
            if (category.Name == "")
            {
                MessageBox.Show("Numele categoriei nu poate fi gol!");
                return;
            }
            if (businessLogicLayer.GetCategory(category.Name) != null)
            {
                MessageBox.Show("Aceasta categorie exista deja!");
                return;
            }
            businessLogicLayer.UpdateCategory(category.CategoryID, category.Name);
        }
    }
}
