using System;
using System.Windows.Forms;
using USP.SUEP.ESI.Lib.Controller;
using USP.SUEP.ESI.Lib.Model;

namespace USP.ESI.SUEP.Desktop
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtAuth_Click(object sender, EventArgs e)
        {
            try
            {
                var _bolValid = ValidaLogin();

                if(_bolValid)
                {
                    var _objUser = new User(TxtLogin.Text, TxtPass.Text);
                    var _bolSuccessAuth = new LoginController().Auth(_objUser);

                    MessageBox.Show(_bolSuccessAuth.ToString());
                }
            }
            catch(ArgumentException _excArgumentException)
            {
                MessageBox.Show(_excArgumentException.Message);
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        private bool ValidaLogin()
        {
            if (TxtLogin.Text.Length < 3 || TxtPass.Text.Length < 3)
                throw new ArgumentException("Login ou senha inválidos");

            return true;
        }
    }
}
