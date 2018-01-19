using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw20_WPF_Elements
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string About { get; set; }
        public override string ToString()
        {
            return string.Format("{0}\r\n{1}", Login, Password);
        }
    }
}
