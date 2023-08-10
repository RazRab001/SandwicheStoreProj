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
using SandwicheStoreProj;

namespace KitchenApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum Ingrid
    {
        Bread,
        Ingridient,
    }
    public partial class MainWindow : Window
    {
        FirstKitchenApp first = new FirstKitchenApp();
        Ingrid actual;
        public MainWindow()
        {
            InitializeComponent();
            ingridientBox.ItemsSource = Enum.GetValues(typeof(Ingrid));

            showList.ItemsSource = first.sandviches.GetCatalog();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(nameBox.Text))
            {
                first.createNewSandvich(nameBox.Text);
                showList.ItemsSource = first.sandviches.GetCatalog();
            }
        }

        private void ingridientBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ingridientBox.SelectedItem != null)
            {
                actual = (Ingrid)ingridientBox.SelectedItem;
                if (actual == Ingrid.Bread)
                {
                    ingridientList.Items.Clear();
                    foreach (Bread b in first.breads.GetCatalog())
                    {
                        ingridientList.Items.Add(b);
                    }
                }
                else if (actual == Ingrid.Ingridient)
                {
                    ingridientList.Items.Clear();
                    foreach (Ingridient i in first.ingridients.GetCatalog())
                    {
                        ingridientList.Items.Add(i);
                    }
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (actual == Ingrid.Bread && !string.IsNullOrEmpty(nameBox.Text))
            {
                Bread bread = Bread.Create(first, nameBox.Text);
                ingridientList.Items.Clear();
                foreach (Bread b in first.breads.GetCatalog())
                {
                    ingridientList.Items.Add(b);
                }
            }
            else if(actual == Ingrid.Ingridient && !string.IsNullOrEmpty(nameBox.Text))
            {
                Ingridient ingridient = Ingridient.Create(first, nameBox.Text);
                ingridientList.Items.Clear();
                foreach (Ingridient i in first.ingridients.GetCatalog())
                {
                    ingridientList.Items.Add(i);
                }
            }
        }
    }
}
