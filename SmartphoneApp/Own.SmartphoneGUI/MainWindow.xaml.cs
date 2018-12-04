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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_AddSmartphone_Click(object sender, RoutedEventArgs e)
        {
            SmartphoneList spList = new SmartphoneList();
            Smartphone sp = new Smartphone();

            sp.InternalId = Convert.ToInt32(TextBox_InternalId.Text);
            sp.Manufacturer = TextBox_Manufacturer.Text;
            sp.Model = TextBox_Model.Text;
            sp.Price = Convert.ToDouble(TextBox_Price.Text);

            spList.Add(sp);
            ListView_Smartphones.Items.Add(sp);


            TextBox_InternalId.Text = string.Empty;
            TextBox_Manufacturer.Text = string.Empty;
            TextBox_Model.Text = string.Empty;
            TextBox_Price.Text = string.Empty;

            TextBox_InternalId.Focus();
        }
    }
}
