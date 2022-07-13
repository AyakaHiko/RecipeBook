﻿using System;
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
        
        private void _test(){
            Recipe r = new Recipe
            {
                Name = "Salad",
                Duration = 20,
                Portions = 5
            };
            Ingredient i1 = new Ingredient
            {
                Name = "Tomato",
                Count = 2,
                Unit = "pieces"
            };

            Ingredient i2 = new Ingredient
            {
                Name = "Cucumber",
                Count = 3,
                Unit = "pieces"
            };
            Ingredient i3 = new Ingredient
            {
                Name = "Onion",
                Count = 1,
                Unit = "pieces"
            };

            r.Ingredients.Add(i1);
            r.Ingredients.Add(i2);
            r.Ingredients.Add(i3);
            r.CookOrder.Add("Get Tomato");
            r.CookOrder.Add("Get Cucumber");
            r.CookOrder.Add("Get Onion");
            r.CookOrder.Add("Mix all");
            r.CookOrder.Add("That's all!");
            _recipes.Add(r);
        }

        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe();
            Edit edit = new Edit(recipe);
            if(edit.ShowDialog()==true)
                _recipes.Add(recipe);
        }

        private void EditBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (RecipeBox.SelectedIndex <0) return;
            Edit edit = new Edit(_recipes[RecipeBox.SelectedIndex]);
            edit.ShowDialog();

            RecipeBox.ItemsSource = null;
            RecipeBox.ItemsSource = _recipes;
        }

        private void DelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if(RecipeBox.SelectedItem==null)return;
            RecipeBox.Items.RemoveAt(RecipeBox.SelectedIndex);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //todo save

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //todo load
            _test();
            _test();
            _test();
            _test();
            _test();
            _test();
            _test();
        }
    }
}
