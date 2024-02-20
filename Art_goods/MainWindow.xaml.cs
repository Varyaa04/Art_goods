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
using Art_goods.Goods;
using Art_goods.PageGoods;
using Art_goods.PageMain;
using Art_goods.Properties;


namespace Art_goods
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppConnect.modeldb = new Entities4();
            AppFrame.frameMain = FrmMain;

            FrmMain.Navigate(new PageMain.PageLogin());


        }

        private void FrmMain_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
