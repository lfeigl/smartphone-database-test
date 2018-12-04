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

        public MainWindow()
        {
            InitializeComponent();
            spList.Deserialize();

            foreach (Smartphone listSp in spList)
            {
                ListView_Smartphones.Items.Add(listSp);
            }
        }

        private void Button_AddSmartphone_Click(object sender, RoutedEventArgs e)
        {
            Smartphone sp = new Smartphone();

            sp.InternalId = Convert.ToInt32(TextBox_InternalId.Text);
            sp.Manufacturer = TextBox_Manufacturer.Text;
            sp.Model = TextBox_Model.Text;
            sp.Price = Convert.ToDouble(TextBox_Price.Text);

            ListView_Smartphones.Items.Add(sp);

            spList.Add(sp);
            spList.Serialize();


            TextBox_InternalId.Text = string.Empty;
            TextBox_Manufacturer.Text = string.Empty;
            TextBox_Model.Text = string.Empty;
            TextBox_Price.Text = string.Empty;

            TextBox_InternalId.Focus();
        }
    }
}
