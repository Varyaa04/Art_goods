using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Security.Cryptography;
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



namespace Art_goods.PageGoods
{
    /// <summary>
    /// Логика взаимодействия для PageGoodsDB.xaml
    /// </summary>
    public partial class PageGoodsDB : Page
    {

        public PageGoodsDB(UserSession session)
        {
            InitializeComponent();
            resd();
            this.session = session;


        }

        List<Goods_Art> goods;
        private UserSession session;

        public void resd()
        {
            goods = AppConnect.modeldb.Goods_Art.ToList();
            if (goods.Count > 0)
            {
                tbCounter.Text = "Найдено " + goods.Count + " товаров";
            }
            else { tbCounter.Text = "Ничего не найдено"; }
            ListProducts.ItemsSource = goods;
            ComboSort.Items.Add("По возрастанию цены");
            ComboSort.Items.Add("По убыванию цены");

            ComboFilter.Items.Add("Скидка от 0 до 10");
            ComboFilter.Items.Add("Скидка от 10 до 15");
            ComboFilter.Items.Add("Скидка от 15");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    private void listGoods_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void UpdateGoods()
    {

        ComboSort.Text = "";
        ComboFilter.Text = "";
        TBoxSearch.Text = "";
        List<Goods_Art> goods = AppConnect.modeldb.Goods_Art.ToList();
        findGoods();

    }

    private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
    Goods_Art[] findGoods()
    {
        List<Goods_Art> product = AppConnect.modeldb.Goods_Art.ToList();
        var productall = product;
        if (TBoxSearch != null)
        {
            product = product.Where(x => x.Name_goods.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
        }

        if (ComboFilter.SelectedIndex > 0)
        {
            switch (ComboFilter.SelectedIndex) {
                case 0:
                    product = product.Where(x => x.ActDisc > 0 && x.ActDisc < 10).ToList();
                    break;
                case 1:
                    product = product.Where(x => x.ActDisc >= 10 && x.ActDisc < 15).ToList();
                    break;
                case 2:
                    product = product.Where(x => x.ActDisc >= 15).ToList();
                    break;
            }
        }
        if (ComboSort.SelectedIndex > 0)
        {
            switch (ComboSort.SelectedIndex)
            {
                case 1:
                    product = product.OrderByDescending(x => x.Cost).ToList(); break;
                case 0:
                    product = product.OrderBy(Z => Z.Cost).ToList();
                    break;
            }
        }

        if (product.Count > 0)
        {
            tbCounter.Text = "Найдено " + product.Count + " товаров";
        }
        else
        {
            tbCounter.Text = "Ничего не найдено";
        }
        ListProducts.ItemsSource = product;
        return product.ToArray();

    }

    private void ListProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void SearchButton_Click(object sender, RoutedEventArgs e)
    {
        findGoods();
    }


    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        var selectedProduct = ListProducts.SelectedItems.Cast<Goods_Art>().ToList();
        if (selectedProduct != null)
        {
            if (MessageBox.Show("Вы точно хотите удалить выбранный товар?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities4.GetContext().Goods_Art.RemoveRange(selectedProduct);
                    Entities4.GetContext().SaveChanges();
                    MessageBox.Show("данные удалены!!");
                    ListProducts.ItemsSource = Entities4.GetContext().Goods_Art.ToList();
                    goods = AppConnect.modeldb.Goods_Art.ToList();
                    if (goods.Count > 0)
                    {
                        tbCounter.Text = "Найдено " + goods.Count + " товаров";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }
        else
        {
            MessageBox.Show("Вы ничего не выбрали", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
        }


    } 

        private void delGoods_Click(object sender, RoutedEventArgs e)
        {

            var selectedProduct = ListProducts.SelectedItems.Cast<Goods_Art>().ToList();
            if (selectedProduct != null)
            {
                if (MessageBox.Show("Вы точно хотите удалить выбранный товар?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        Entities4.GetContext().Goods_Art.RemoveRange(selectedProduct);
                        Entities4.GetContext().SaveChanges();
                        MessageBox.Show("данные удалены!!");
                        ListProducts.ItemsSource = Entities4.GetContext().Goods_Art.ToList();
                        goods = AppConnect.modeldb.Goods_Art.ToList();
                        if (goods.Count > 0)
                        {
                            tbCounter.Text = "Найдено " + goods.Count + " товаров";
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }

            }
            else
            {
                MessageBox.Show("Вы ничего не выбрали", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void Addkorzina_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Basket goodsobj = new Basket()
                {
                    idBasket = +1,
                    IdUser = 1,
                    
                };
                AppConnect.modeldb.Basket.Add(goodsobj);
                AppConnect.modeldb.SaveChanges();
                MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.frameMain.Navigate(new Basketp((sender as Button).DataContext as Basket));
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities4.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListProducts.ItemsSource = Entities4.GetContext().Goods_Art.ToList();
            }
        }

        private void EditGoods_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new EditGoods((sender as MenuItem).DataContext as Goods_Art));

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddGoods());
        }

        private void refButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateGoods();
            findGoods();
        }

        public void RefForDel()
        {
            Entities4.GetContext().SaveChanges();
            List<Goods_Art> newgoods = AppConnect.modeldb.Goods_Art.ToList();
            ListProducts.ItemsSource = newgoods;

        }
        

        private void editbtn_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new EditGoods((sender as Button).DataContext as Goods_Art));
        }


        private void addBasket_Click(object sender, RoutedEventArgs e)
        {
          AppFrame.frameMain.Navigate(new Basketp((sender as Button).DataContext as Basket));
        }

        private void delGoods_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ListProducts.SelectedItems.Cast<Goods_Art>().ToList();
            if (selectedProduct != null)
            {
                if (MessageBox.Show("Вы точно хотите удалить выбранный товар?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        Entities4.GetContext().Goods_Art.RemoveRange(selectedProduct);
                        Entities4.GetContext().SaveChanges();
                        MessageBox.Show("данные удалены!!");
                        ListProducts.ItemsSource = Entities4.GetContext().Goods_Art.ToList();
                        goods = AppConnect.modeldb.Goods_Art.ToList();
                        if (goods.Count > 0)
                        {
                            tbCounter.Text = "Найдено " + goods.Count + " товаров";
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }

            }
            else
            {
                MessageBox.Show("Вы ничего не выбрали", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
    }
   
