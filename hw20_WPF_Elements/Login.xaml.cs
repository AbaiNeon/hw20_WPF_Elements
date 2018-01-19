using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace hw20_WPF_Elements
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            Regisrration registrtion1 = new Regisrration();
            this.NavigationService.Navigate(registrtion1);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //проверка
            if (textboxLogin.Text == string.Empty || textboxPassword.Password == string.Empty)
            {
                MessageBox.Show("Заполнены не все поля");
                return;
            }

            List<User> userList = new List<User>();

            if (File.Exists(@"C:\name_of_folder\data.json"))
            {
                userList = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(@"C:\name_of_folder\data.json"));
            }
            else
            {
                MessageBox.Show("В системе ни одного пользователя");
                return;
            }
            
            string login = textboxLogin.Text;
            string password = textboxPassword.Password;

            User user = new User() { Login = login, Password = password, About = "male", Mail = "user1" };

            bool isRegistered = false;

            foreach (var item in userList)
            {
                if (item.Login == login && item.Password == password)
                {
                    isRegistered = true;
                }
            }

            if (isRegistered)
            {
                string json2 = JsonConvert.SerializeObject(user);

                using (StreamWriter writer = new StreamWriter(@"C:\name_of_folder\lastRegisteredUser.json"))
                {
                    writer.WriteLine(json2);
                }

                //переход к 3 странице
                Greetings greetings1 = new Greetings();
                this.NavigationService.Navigate(greetings1);
            }
            else
            {
                MessageBox.Show("Пользователя с таким логином и паролем не существует в системе");
                return;
            }
        }
    }
}