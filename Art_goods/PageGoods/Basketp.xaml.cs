using Art_goods.Goods;
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

namespace Art_goods.PageGoods
{
    /// <summary>
    /// Логика взаимодействия для Basketp.xaml
    /// </summary>
    public partial class Basketp : Page
    {
        private Basket _goods = new Basket();
        public Basketp(Basket goodss)
        {
            InitializeComponent();
            if (goodss != null)
            {
                _goods = goodss;
            }

            DataContext = _goods;
            ListProducts.Items.Add(_goods);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void delbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
