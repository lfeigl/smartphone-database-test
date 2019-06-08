using Microsoft.Win32;
using Own.SmartphoneLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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
                InternalId = TextBox_InternalId.Text,
                Manufacturer = TextBox_Manufacturer.Text,
                Model = TextBox_Model.Text,
            };

            try
            {
                sp.Price = Convert.ToDouble(TextBox_Price.Text);
            }
            catch (Exception ex) when (ex is FormatException || ex is OverflowException)
            {
                sp.Price = 0;
            }

            spList.Add(sp);
            ListView_Smartphones.Items.Add(sp);
            AddManufacturerFilter(sp.Manufacturer);

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
                string path = ofd.FileName;
                ISerializable serializer = GetSerializer(path);

                if (serializer != null)
                {
                    spList.Deserialize(serializer, path);
                    ListView_Smartphones.Items.Clear();
                    manufacturers.Clear();

                    foreach (Smartphone listSp in spList)
                    {
                        ListView_Smartphones.Items.Add(listSp);
                        AddManufacturerFilter(listSp.Manufacturer);
                    }
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
                string path = sfd.FileName;
                ISerializable serializer = GetSerializer(path);

                if (serializer != null)
                {
                    spList.Serialize(serializer, path);
                }
            }
        }

        private void ComboBox_FilterManufacturer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string manufacturer = (string)ComboBox_FilterManufacturer.SelectedItem;
            SmartphoneList filtered = null;

            ListView_Smartphones.Items.Clear();

            if (manufacturer != null && manufacturer.Equals(MANUFACTURER_FILTER_ALL))
            {
                filtered = spList;
            }
            else
            {
                filtered = spList.GetByManufacturer(manufacturer);
            }

            foreach (Smartphone listSp in filtered)
            {
                ListView_Smartphones.Items.Add(listSp);
            }
        }

        private void AddManufacturerFilter(string manufacturer)
        {
            ComboBox_FilterManufacturer.Items.Clear();
            ComboBox_FilterManufacturer.Items.Add(MANUFACTURER_FILTER_ALL);
            ComboBox_FilterManufacturer.SelectedItem = MANUFACTURER_FILTER_ALL;
            manufacturers.Add(manufacturer);

            foreach (string listManufacturer in manufacturers)
            {
                ComboBox_FilterManufacturer.Items.Add(listManufacturer);
            }
        }

        private ISerializable GetSerializer(string path)
        {
            string ext = Path.GetExtension(path);
            ISerializable serializer = null;

            if (ext.Equals(".json"))
            {
                serializer = new JSONSerializer();
            }
            else if (ext.Equals(".xml"))
            {
                serializer = new XMLSerializer();
            }
            else if (ext.Equals(".csv"))
            {
                serializer = new CSVSerializer();
            }
            else if (ext.Equals(".bin"))
            {
                serializer = new BinarySerializer();
            }

            return serializer;
        }
    }
}
