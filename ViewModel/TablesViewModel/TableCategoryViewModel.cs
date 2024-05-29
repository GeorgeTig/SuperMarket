using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Models.Entity;
using SuperMarket.Models.BusinessLogicLayer;
using SuperMarket.Models.DataAccessLayer;
using System.Windows.Input;
using ICommandDemoAgain.Commands;
using System.Windows.Controls;
using SuperMarket.View.EditPages;


namespace SuperMarket.ViewModel.TablesViewModel
{
    internal class TableCategoryViewModel
    {
        public List<Category> Categories { get; set; }
        public BusinessLogicLayer BusinessLogicLayer { get; set; }

        public ICommand AddCategoryCommand { get; set; }
        public ICommand ModifyCategoryCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }

        public object SelectedItem { get; set; } = null;
        public TableCategoryViewModel() 
        {
            Categories = new List<Category>();
            BusinessLogicLayer = new BusinessLogicLayer();
            Categories = BusinessLogicLayer.GetAllCategories();
            AddCategoryCommand = new RelayCommand((o) =>
            {
                if (o is not Page page)
                {
                    return;
                }
                page.NavigationService.Navigate(new EditCategoryPage());
            });

            ModifyCategoryCommand = new RelayCommand((o) =>
            {
                if (o is not Page page)
                {
                    return;
                }

                if (SelectedItem == null)
                {
                    return;
                }

                page.NavigationService.Navigate(new EditCategoryPage(SelectedItem as Category));
            });

            DeleteCategoryCommand = new RelayCommand((o) =>
            {
                if (SelectedItem == null)
                {
                    return;
                }
                Category category1 = SelectedItem as Category;
                BusinessLogicLayer.DeleteCategory(category1.CategoryID);
                Categories = BusinessLogicLayer.GetAllCategories();
            });
        }
    }
}
