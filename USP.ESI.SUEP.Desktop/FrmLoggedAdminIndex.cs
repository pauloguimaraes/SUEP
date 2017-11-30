using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using USP.ESI.SUEP.Desktop.Binding;
using USP.ESI.SUEP.Desktop.SessionInfos;
using USP.ESI.SUEP.Lib.Controller;

namespace USP.ESI.SUEP.Desktop
{
    public partial class FrmLoggedAdminIndex : Form
    {
        public FrmLoggedAdminIndex()
        {
            InitializeComponent();

            CbbUserType.ValueMember = "Value";
            CbbUserType.DisplayMember = "Text";
        }

        private void FrmLoggedAdminIndex_Load(object sender, System.EventArgs e)
        {
            LoadUserTypes();

            LoadRegisteredUsers();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }
        
        private void LoadRegisteredUsers()
        {
            try
            {
                DtgUsers.AutoGenerateColumns = true;
                DtgUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                var _objLstUsers = new UserController().Get();
                var _objLstBindingUsers = new List<BindingUser>();

                foreach(var _objUser in _objLstUsers)
                {
                    _objLstBindingUsers.Add(new BindingUser()
                    {
                        CPF = _objUser.CPF,
                        Id = _objUser.Id,
                        Login = _objUser.Login,
                        Nome = _objUser.Name,
                        Senha = Encoding.UTF8.GetString(Convert.FromBase64String(_objUser.Pass)),
                        Tipo_Usuario = _objUser.AccessProfile.GetUserTypeAsString(),
                        IdUserType = _objUser.AccessProfile.GetUserTypeId(),
                        IsActive = _objUser.Active,
                        Ativo = _objUser.Active ? "SIM" : "NÃO"
                    });
                }

                var _objBinding = new BindingList<BindingUser>(_objLstBindingUsers);
                DtgUsers.DataSource = _objBinding;

                DtgUsers.Columns["IdUserType"].Visible = false;
                DtgUsers.Columns["IsActive"].Visible = false;
                DtgUsers.Columns["Id"].Visible = false;
                DtgUsers.Columns["Senha"].Visible = false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void LoadUserTypes()
        {
            try
            {
                var _objLstUserType = new UserTypeController().Get();

                foreach (var _objUserType in _objLstUserType)
                    CbbUserType.Items.Add(new { Text = _objUserType, Value = _objUserType });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void BtnExcluir_Consulta_Click(object sender, EventArgs e)
        {
            TxtIdUsuario.Text = DtgUsers.CurrentRow.Cells["Id"].Value.ToString();

            var _bolCouldRemove = new UserController().Delete(new Lib.Model.User() { Id = Convert.ToInt32(TxtIdUsuario.Text) });

            if (_bolCouldRemove)
                MessageBox.Show("Excluído com sucesso!");

            LoadRegisteredUsers();
        }

        private void BtnEditar_Consulta_Click(object sender, EventArgs e)
        {
            TxtCPF.Text = DtgUsers.CurrentRow.Cells["CPF"].Value.ToString();
            TxtName.Text = DtgUsers.CurrentRow.Cells["Nome"].Value.ToString();
            TxtLogin.Text = DtgUsers.CurrentRow.Cells["Login"].Value.ToString();
            TxtPass.Text = DtgUsers.CurrentRow.Cells["Senha"].Value.ToString();
            CbbUserType.SelectedIndex = Convert.ToInt32(DtgUsers.CurrentRow.Cells["IdUserType"].Value.ToString()) - 1;
            ChbActive.Checked = Convert.ToBoolean(DtgUsers.CurrentRow.Cells["IsActive"].Value.ToString());

            TxtIdUsuario.Text = DtgUsers.CurrentRow.Cells["Id"].Value.ToString();
        }

        private void BtnCancelar_Consulta_Click(object sender, EventArgs e)
        {
            CleanScreen();
        }

        private void CleanScreen()
        {
            TxtIdUsuario.Text =
                            TxtName.Text =
                            TxtCPF.Text =
                            TxtLogin.Text =
                            TxtPass.Text = string.Empty;
            CbbUserType.SelectedIndex = -1;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var _bolValid = ValidaCampos();

                if (_bolValid)
                {
                    var _objUser = new Lib.Model.User
                    {
                        CPF = TxtCPF.Text,
                        Name = TxtName.Text,
                        Login = TxtLogin.Text,
                        Pass = Convert.ToBase64String(Encoding.UTF8.GetBytes(TxtPass.Text)),
                        Active = ChbActive.Checked,
                        IdAccessProfile = CbbUserType.SelectedIndex + 1,
                        HourPrice = Convert.ToDecimal(TxtHourPrice.Text)
                    };

                    if (!TxtIdUsuario.Text.Equals(string.Empty))
                        _objUser.Id = Convert.ToInt32(TxtIdUsuario.Text);

                    var _bolCouldChange = new UserController().Save(_objUser);

                    if (_bolCouldChange)
                        MessageBox.Show("Operação concluída com sucesso!");

                    CleanScreen();
                    LoadRegisteredUsers();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidaCampos()
        {
            var _strMensagem = string.Empty;

            if (TxtLogin.Text.Length < 3 || TxtLogin.Text.Length > 12)
                _strMensagem += "Login com tamanho inválido\n";

            if (TxtPass.Text.Length < 6 || TxtPass.Text.Length > 255)
                _strMensagem += "Senha com tamanho inválido\n";

            if (TxtName.Text.Length < 4 || TxtName.Text.Length > 255)
                _strMensagem += "Nome com tamanho inválido\n";

            if (TxtCPF.Text.Length != 11)
                _strMensagem += "CPF inválido\n";

            if (CbbUserType.SelectedIndex < 0)
                _strMensagem += "Tipo de usuário inválido\n";
            
            if (_strMensagem.Equals(string.Empty))
                return true;
            else
                throw new ArgumentException(_strMensagem);
        }

        private void LblExit_Click(object sender, EventArgs e)
        {
            LoggedUser.USER = null;

            Hide();
            new FrmLogin().Show();
        }

        private void CbbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblHourPrice.Visible =
                TxtHourPrice.Visible = CbbUserType.SelectedText.ToUpper().Equals("MEDICO");
        }
    }
}
