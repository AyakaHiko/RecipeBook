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
using System.Windows.Shapes;

namespace cook
{
    public partial class Edit : Window
    {
        private ObservableCollection<Ingredient> _ingredients;
        private ObservableCollection<string> _order;
        public Edit(Recipe recipe)
        {
            InitializeComponent();
            EditGrid.DataContext = recipe;

            _ingredients = new ObservableCollection<Ingredient>(recipe.Ingredients);
            _order = new ObservableCollection<string>(recipe.CookOrder);
            _init();

        }

        private void _init()
        {
            IngredientBox.ItemsSource = _ingredients;
            OrderBox.ItemsSource = _order;
        }

        private void OkBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //todo check 

            Recipe recipe = EditGrid.DataContext as Recipe;
            recipe.CookOrder = new List<string>(_order);
            recipe.Ingredients = new List<Ingredient>(_ingredients);
            DialogResult = true;
        }

        private void IAddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Ingredient ingredient = new Ingredient
                {
                    Unit = IUnit.Text,
                    Name = IName.Text,
                    Count = int.Parse(ICount.Text)
                };
                if (_ingredients.Contains(ingredient)) return;
                _ingredients.Add(ingredient);
            }
            catch
            {
                // ignored
            }
        }

        private void IDelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if(IngredientBox.SelectedItem == null) return;
            _ingredients.Remove((Ingredient)IngredientBox.SelectedItem);
        }

        private void OAddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (_order.Contains(CookStep.Text)) return;
            _order.Add(CookStep.Text);
            CookStep.Text = "";
        }

        private void ODelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if(OrderBox.SelectedItem == null) return;
            _order.Remove((string)OrderBox.SelectedItems[0]);
        }

        private void UpBtn_OnClick(object sender, RoutedEventArgs e)
        {
            MoveItem(-1);
        }

        private void DownBtn_OnClick(object sender, RoutedEventArgs e)
        {
            MoveItem(1);
        }

        public void MoveItem(int direction)
        {
            if (OrderBox.SelectedIndex < 0) return;

            var newIndex = OrderBox.SelectedIndex + direction;
            if (newIndex < 0 || newIndex >= OrderBox.Items.Count)
                return;

            var item = _order[OrderBox.SelectedIndex];
            _order.Remove(item);
            _order.Insert(newIndex, item);



        }
    }
}
