using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USP.ESI.SUEP.Desktop.Binding
{
    public class BindingUser
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string UserType { get; set; }
    }
}
