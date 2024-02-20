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


namespace Art_goods.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }
         private int GetUserRole(string username, string password)
        {
            using (var dbContext = new Entities4())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

                if (user != null)
                {
                    return (int)user.Role;
                }
            }

            return 0;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.modeldb.Users.FirstOrDefault(x => x.Login == txbLogin.Text && x.Password == psbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    UserSession session = new UserSession
                    {
                        UserId = userObj.IdUsers,
                        UserName = userObj.Login 
                    };

                    if (userObj.Role == 1)
                    {
                        MessageBox.Show("Здравствуйте, Админ " + userObj.Surname + " " + userObj.Name + "!",
                        "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        AppFrame.frameMain.Navigate(new PageGoods.PageGoodsDB(session));
                    }
                    else if (userObj.Role == 2)
                    {
                        MessageBox.Show("Здравствуйте, " + userObj.Surname + " " + userObj.Name + "!",
                        "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        AppFrame.frameMain.Navigate(new PageGoods.PageGoodsDB(session));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message + "\nКритическая работа приложения!",
                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageMain.PageCreateAcc());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
