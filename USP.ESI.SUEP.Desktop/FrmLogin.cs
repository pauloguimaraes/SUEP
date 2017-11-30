using System;
using System.Windows.Forms;
using USP.ESI.SUEP.Desktop.SessionInfos;
using USP.ESI.SUEP.Lib.Controller;
using USP.ESI.SUEP.Lib.Model;
using USP.ESI.SUEP.Lib.Model.Constants;

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
                    var _objLoggedUser = new LoginController().Auth(_objUser);

                    LoggedUser.USER = _objLoggedUser;
                    
                    var _strUserType = _objLoggedUser.AccessProfile.GetUserTypeAsString();
                    switch(_strUserType)
                    {
                        case UserTypeConstants.ADMIN:
                            Hide();
                            new FrmLoggedAdminIndex().Show();
                            break;
                        case UserTypeConstants.DOCTO:
                            Hide();
                            new FrmAgenda().Show();
                            break;
                        default:
                            TxtLogin.Text = TxtPass.Text = string.Empty;
                            throw new Exception("Perfil de acesso não mapeado para acesso no sistema");
                    }
                }
            }
            catch(ArgumentException _excArgumentException)
            {
                MessageBox.Show(_excArgumentException.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
