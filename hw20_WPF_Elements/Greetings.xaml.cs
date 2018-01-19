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
using Newtonsoft.Json;
using System.IO;

namespace hw20_WPF_Elements
{
    /// <summary>
    /// Interaction logic for Greetings.xaml
    /// </summary>
    public partial class Greetings : Page
    {
        public Greetings()
        {
            InitializeComponent();

            User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(@"C:\name_of_folder\lastRegisteredUser.json"));

            label.Content = "Приветствую, " + user.Login;
        }
    }
}
