using Microsoft.Win32;
using Own.SmartphoneLib;
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

namespace Own.SmartphoneGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SmartphoneList spList = new SmartphoneList();
        private HashSet<string> manufacturers = new HashSet<string>();
        private string MANUFACTURER_FILTER_ALL = "All";
        private string FILE_DIALOG_FILTER = "JSON files|*.json|XML files|*.xml|CSV files|*.csv|Binary files|*.bin";

        public MainWindow()
        {
            InitializeComponent();
            ComboBox_FilterManufacturer.Items.Add(MANUFACTURER_FILTER_ALL);
            ComboBox_FilterManufacturer.SelectedItem = MANUFACTURER_FILTER_ALL;
        }

        private void Button_AddSmartphone_Click(object sender, RoutedEventArgs e)
        {
            Smartphone sp = new Smartphone
            {
                InternalId = Convert.ToInt32(TextBox_InternalId.Text),
                Manufacturer = TextBox_Manufacturer.Text,
                Model = TextBox_Model.Text,
                Price = Convert.ToDouble(TextBox_Price.Text)
            };

            ListView_Smartphones.Items.Add(sp);
            AddManufacturerFilter(sp.Manufacturer);
            spList.Add(sp);

            TextBox_InternalId.Text = string.Empty;
            TextBox_Manufacturer.Text = string.Empty;
            TextBox_Model.Text = string.Empty;
            TextBox_Price.Text = string.Empty;

            TextBox_InternalId.Focus();
        }

        private void Button_OpenList_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = FILE_DIALOG_FILTER
            };

            if (ofd.ShowDialog().Equals(true))
            {
                spList.Deserialize(ofd.FileName);
                ListView_Smartphones.Items.Clear();
                manufacturers.Clear();

                foreach (Smartphone listSp in spList)
                {
                    ListView_Smartphones.Items.Add(listSp);
                    AddManufacturerFilter(listSp.Manufacturer);
                }
            }
        }

        private void Button_SaveList_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = "MySmartphoneList",
                Filter = FILE_DIALOG_FILTER
            };

            if (sfd.ShowDialog().Equals(true))
            {
                spList.Serialize(sfd.FileName);
            }
        }

        private void ComboBox_FilterManufacturer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddManufacturerFilter(string manufacturer)
        {
            ComboBox_FilterManufacturer.Items.Clear();
            ComboBox_FilterManufacturer.Items.Add(MANUFACTURER_FILTER_ALL);
            ComboBox_FilterManufacturer.SelectedItem = MANUFACTURER_FILTER_ALL;
            manufacturers.Add(manufacturer);

            foreach(string listManufacturer in manufacturers)
            {
                ComboBox_FilterManufacturer.Items.Add(listManufacturer);
            }
        }
    }
}
