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

            foreach(Sandvich s in first.sandviches.GetCatalog())
            {
                showList.Items.Add(s);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(nameBox.Text))
            {
                first.createNewSandvich(nameBox.Text);
                showList.Items.Clear();
                foreach (Sandvich s in first.sandviches.GetCatalog())
                {
                    showList.Items.Add(s);
                }
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
                    List<Bread> list1 = first.breads.GetCatalog();
                    list1.Sort(new SortByName());
                    foreach (Bread b in list1)
                    {
                        ingridientList.Items.Add(b);
                    }
                }
                else if (actual == Ingrid.Ingridient)
                {
                    ingridientList.Items.Clear();
                    List<Ingridient> list2 = first.ingridients.GetCatalog();
                    list2.Sort(new SortByName());
                    foreach (Ingridient i in list2)
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
                List<Bread> list1 = first.breads.GetCatalog();
                list1.Sort(new SortByName());
                foreach (Bread b in list1)
                {
                    ingridientList.Items.Add(b);
                }
            }
            else if(actual == Ingrid.Ingridient && !string.IsNullOrEmpty(nameBox.Text))
            {
                Ingridient ingridient = Ingridient.Create(first, nameBox.Text);
                ingridientList.Items.Clear();
                List<Ingridient> list2 = first.ingridients.GetCatalog();
                list2.Sort(new SortByName());
                foreach (Ingridient i in list2)
                {
                    ingridientList.Items.Add(i);
                }
            }
        }
        private void AddToButton_Click(object sender, RoutedEventArgs e)
        {
            string item = ingridientList.Items[ingridientList.SelectedIndex].ToString();
            if (actual == Ingrid.Bread)
            {
                first.addBreadToSandvich(item);
                showList.Items.Clear();
                showList.Items.Add(item);
            }
            else if (actual == Ingrid.Ingridient)
            {
                first.addIngridientToSandvich(item);
                showList.Items.Add(item);
            }
        }

    }
}
