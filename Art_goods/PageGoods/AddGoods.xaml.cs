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

namespace Art_goods.PageGoods
{
    /// <summary>
    /// Логика взаимодействия для AddGoods.xaml
    /// </summary>
    public partial class AddGoods : Page
    {
        private Entities4 _currentGoods = new Entities4();
        public AddGoods()
        {
            List<Goods_Art> goods = AppConnect.modeldb.Goods_Art.ToList();

            InitializeComponent();
           

            DataContext = _currentGoods;
            ComboCategory.ItemsSource = Entities4.GetContext().Category.Select(x => x.Name).ToList();
            ComboMan.ItemsSource = Entities4.GetContext().Manufacturer.Select(x => x.Name).ToList();
            ComboProvider.ItemsSource = Entities4.GetContext().Provider.Select(x => x.Name).ToList();
            ComboUnit.ItemsSource = Entities4.GetContext().Unit.Select(x => x.Name).ToList();
            ComboName.ItemsSource = Entities4.GetContext().Name_goods.Select(x => x.Name).ToList();
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.modeldb.Goods_Art.Count(x => x.Article == article.Text) > 0)
            {
                MessageBox.Show("Товар с таким артиклем существует!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else if(article.Text == "")
            {
                MessageBox.Show("Введите значение 'артикль'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else if(instock.Text == "")
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
            else
            {
                int stock = Convert.ToInt32(instock.Text);
                int act = Convert.ToInt32(actdics.Text);
                int max = Convert.ToInt32(maxdisc.Text);
                int cost = Convert.ToInt32(price.Text);
                try
                {
                    Goods_Art goodsobj = new Goods_Art()
                    {
                        Article = article.Text,
                        Name = Convert.ToInt32(ComboName.SelectedIndex + 1),
                        Unit = Convert.ToInt32(ComboUnit.SelectedIndex + 1),
                        Cost = cost,
                        MaxSale = max,
                        Manufacturer = Convert.ToInt32(ComboMan.SelectedIndex + 1),
                        Provider = Convert.ToInt32(ComboProvider.SelectedIndex + 1),
                        Category = Convert.ToInt32(ComboCategory.SelectedIndex + 1),
                        ActDisc = act,
                        OnStock = stock,
                        Description = desc.Text,
                        Image = null
                    }; AppConnect.modeldb.Goods_Art.Add(goodsobj);
                    AppConnect.modeldb.SaveChanges();
                    MessageBox.Show("Товар успешно добавлен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    AppFrame.frameMain.Navigate(new PageGoodsDB());
                }
                catch
                {
                    MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }

        
        private void instock_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BGoBackbutton_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }
    }
}
