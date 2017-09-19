using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using USP.ESI.SUEP.Desktop.Binding;
using USP.ESI.SUEP.Lib.Controller;

namespace USP.ESI.SUEP.Desktop
{
    public partial class FrmLoggedAdminIndex : Form
    {
        public FrmLoggedAdminIndex()
        {
            InitializeComponent();
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

        private void DtgUsers_SelectionChanged(object sender, EventArgs e)
        {
            //if(DtgUsers.CurrentRow.Index != -1)
            //{
            //    var _intCurrentRow = DtgUsers.CurrentRow.Index;
            TxtCPF.Text = DtgUsers.CurrentRow.Cells["CPF"].Value.ToString();
            TxtName.Text = DtgUsers.CurrentRow.Cells["Name"].Value.ToString();
            TxtLogin.Text = DtgUsers.CurrentRow.Cells["Login"].Value.ToString();
            TxtPass.Text = DtgUsers.CurrentRow.Cells["Pass"].Value.ToString();
            CbbUserType.SelectedValue = DtgUsers.CurrentRow.Cells["UserType"].Value.ToString();
            //}
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
                        Name = _objUser.Name,
                        Pass = _objUser.Pass,
                        UserType = _objUser.AccessProfile.GetUserTypeAsString()
                    });
                }

                var _objBinding = new BindingList<BindingUser>(_objLstBindingUsers);
                DtgUsers.DataSource = _objBinding;
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
                    CbbUserType.Items.Add(_objUserType);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
