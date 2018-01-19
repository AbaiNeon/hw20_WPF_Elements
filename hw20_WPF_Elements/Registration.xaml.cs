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
using Newtonsoft.Json;

namespace hw20_WPF_Elements
{
    /// <summary>
    /// Interaction logic for Regisrration.xaml
    /// </summary>
    
    
    public partial class Regisrration : Page
    {
        public Regisrration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //проверка
            if (textboxLogin.Text == string.Empty || textboxPassword.Text == string.Empty || textboxConfirmPassword.Text == string.Empty || textboxMail.Text == string.Empty || textboxAbout.Text == string.Empty)
            {
                MessageBox.Show("Заполнены не все поля");
                return;
            }

            if (textboxPassword.Text != textboxConfirmPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            //сериализация userList в файл (json)
            List<User> userList = File.Exists(@"C:\name_of_folder\data.json") ? JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(@"C:\name_of_folder\data.json")) : new List<User>();
            
            User user1 = new User() { Login = textboxLogin.Text, Password = textboxPassword.Text, Mail = textboxMail.Text, About = textboxAbout.Text };

            userList.Add(user1);

            string json = JsonConvert.SerializeObject(userList);

            using (StreamWriter writer = new StreamWriter(@"C:\name_of_folder\data.json"))
            {
                writer.WriteLine(json);
            }

            //переход к 1 странице
            Login login1 = new Login();
            this.NavigationService.Navigate(login1);
        }
    }
}
