using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace cook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Recipe> _recipes = new ObservableCollection<Recipe>();
        public MainWindow()
        {
            InitializeComponent();
            RecipeBox.ItemsSource = _recipes;
        }
        

        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe();
            Edit edit = new Edit(recipe);
            if(edit.ShowDialog()==true)
                _recipes.Add(recipe);

            //todo check
        }

        private void EditBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //todo
        }

        private void DelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //todo
        }
    }
}
