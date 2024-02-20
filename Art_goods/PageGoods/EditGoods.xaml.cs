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
using Art_goods.PageGoods;
using Art_goods.PageMain;
using Art_goods.Properties;
using System.Data.Entity;

namespace Art_goods.PageGoods
{
    /// <summary>
    /// Логика взаимодействия для EditGoods.xaml
    /// </summary>
    public partial class EditGoods : Page
    {
        private Goods_Art _currentGoods = new Goods_Art();

        public EditGoods(Goods_Art selectedProduct)
        {
            InitializeComponent();
            
            if(selectedProduct != null )
            {
                _currentGoods = selectedProduct;
            }
            DataContext = _currentGoods;
            ComboCategory.ItemsSource = Entities4.GetContext().Category.Select(x => x.Name).ToList();
            ComboMan.ItemsSource = Entities4.GetContext().Manufacturer.Select(x => x.Name).ToList();
            ComboProvider.ItemsSource = Entities4.GetContext().Provider.Select(x => x.Name).ToList();
            ComboUnit.ItemsSource = Entities4.GetContext().Unit.Select(x => x.Name).ToList();
            ComboName.ItemsSource = Entities4.GetContext().Name_goods.Select(x => x.Name).ToList();
           
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(_currentGoods.Article))
            {
                errors.AppendLine("Введите артикль");
            }
            else if (instock.Text == "")
            {
                MessageBox.Show("Введите значение 'в наличии'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            if (actdics.Text == "")
            {
                MessageBox.Show("Введите значение 'актуальная скидка'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else if (maxdisc.Text == "")
            {
                MessageBox.Show("Введите значение 'максимальная скидка'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else if (price.Text == "")
            {
                MessageBox.Show("Введите значение 'Цена'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else if (instock.Text == "")
            {
                MessageBox.Show("Введите значение 'в наличии'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentGoods.idGoods_Art == 0)
            {
                Entities4.GetContext().Goods_Art.Add(_currentGoods);
            }
            try
            {
                Entities4.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно изменены!");
                AppFrame.frameMain.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void article_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BGoBackbutton_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }
    }
}
