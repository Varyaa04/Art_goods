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
    /// Логика взаимодействия для PageCreateAcc.xaml
    /// </summary>
    public partial class PageCreateAcc : Page
    {
        public PageCreateAcc()
        {
            InitializeComponent();
        }

        private void pass2txt_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pass2txt.Password != passtxt.Text)
            {
                reg.IsEnabled = false;
                pass2txt.Background = Brushes.LightCoral;
                pass2txt.BorderBrush = Brushes.Red;
            }
            else
            {
                reg.IsEnabled = true;
                pass2txt.Background = Brushes.LightGreen;
                pass2txt.BorderBrush = Brushes.Green;
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.modeldb.Users.Count(x => x.Login == logintxt.Text) > 0)
            {
                MessageBox.Show("Пользователь существует!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                Users userobj = new Users()
                {
                    Login = logintxt.Text,
                    Name = tnametxt.Text,
                    Surname = tsurnametxt1.Text,
                    Password = passtxt.Text,
                    Role = 2
                };
                AppConnect.modeldb.Users.Add(userobj);
                AppConnect.modeldb.SaveChanges();
                MessageBox.Show("Вы успешно зарегистировались!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
