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

namespace Tehtava2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyXMLData data = new MyXMLData();
        public MainWindow()
        {
            InitializeComponent();

            dgCountries.ItemsSource = data.showData();
            cbContinent.ItemsSource = data.showContinents();
            setCountryAndPopulation();
        }

        private void setCountryAndPopulation()
        {
            lblCountry.Content = data.getCountryCount();
            lblPopulation.Content = data.getCombinedPopulation();
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            dgCountries.ItemsSource = data.showData();
            setCountryAndPopulation();
        }

        private void btnPopulation_Click(object sender, RoutedEventArgs e)
        {
            dgCountries.ItemsSource = data.showTenHighestPopulation();
            setCountryAndPopulation();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgCountries.ItemsSource = data.showDataByContinent(cbContinent.SelectedItem.ToString());
            setCountryAndPopulation();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            //dgCountries.ItemsSource = null;
            dgCountries.ItemsSource = data.showDataFind(txtFind.Text);
            setCountryAndPopulation();
        }

        private void btnSurface_Click(object sender, RoutedEventArgs e)
        {
            dgCountries.ItemsSource = data.showTenHighestSurfaceArea();
            setCountryAndPopulation();
        }
    }
}
