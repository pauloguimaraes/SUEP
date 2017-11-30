namespace USP.ESI.SUEP.Desktop
{
    partial class FrmLoggedAdminIndex
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoggedAdminIndex));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TbpUser = new System.Windows.Forms.TabPage();
            this.TxtHourPrice = new System.Windows.Forms.TextBox();
            this.LblHourPrice = new System.Windows.Forms.Label();
            this.ChbActive = new System.Windows.Forms.CheckBox();
            this.BtnEditar_Consulta = new System.Windows.Forms.Button();
            this.BtnExcluir_Consulta = new System.Windows.Forms.Button();
            this.BtnCancelar_Consulta = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TxtIdUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CbbUserType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.TxtLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCPF = new System.Windows.Forms.TextBox();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtgUsers = new System.Windows.Forms.DataGridView();
            this.LblExit = new System.Windows.Forms.Label();
            this.LblOla = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.TbpUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TbpUser);
            this.tabControl1.Location = new System.Drawing.Point(12, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // TbpUser
            // 
            this.TbpUser.BackColor = System.Drawing.SystemColors.Control;
            this.TbpUser.Controls.Add(this.TxtHourPrice);
            this.TbpUser.Controls.Add(this.LblHourPrice);
            this.TbpUser.Controls.Add(this.ChbActive);
            this.TbpUser.Controls.Add(this.BtnEditar_Consulta);
            this.TbpUser.Controls.Add(this.BtnExcluir_Consulta);
            this.TbpUser.Controls.Add(this.BtnCancelar_Consulta);
            this.TbpUser.Controls.Add(this.BtnSave);
            this.TbpUser.Controls.Add(this.TxtIdUsuario);
            this.TbpUser.Controls.Add(this.label6);
            this.TbpUser.Controls.Add(this.CbbUserType);
            this.TbpUser.Controls.Add(this.label5);
            this.TbpUser.Controls.Add(this.TxtPass);
            this.TbpUser.Controls.Add(this.TxtLogin);
            this.TbpUser.Controls.Add(this.label4);
            this.TbpUser.Controls.Add(this.label3);
            this.TbpUser.Controls.Add(this.TxtCPF);
            this.TbpUser.Controls.Add(this.TxtName);
            this.TbpUser.Controls.Add(this.label2);
            this.TbpUser.Controls.Add(this.label1);
            this.TbpUser.Controls.Add(this.DtgUsers);
            this.TbpUser.Location = new System.Drawing.Point(4, 22);
            this.TbpUser.Name = "TbpUser";
            this.TbpUser.Padding = new System.Windows.Forms.Padding(3);
            this.TbpUser.Size = new System.Drawing.Size(652, 411);
            this.TbpUser.TabIndex = 0;
            this.TbpUser.Text = "Manter Usuário";
            // 
            // TxtHourPrice
            // 
            this.TxtHourPrice.Location = new System.Drawing.Point(548, 127);
            this.TxtHourPrice.Name = "TxtHourPrice";
            this.TxtHourPrice.Size = new System.Drawing.Size(98, 20);
            this.TxtHourPrice.TabIndex = 21;
            this.TxtHourPrice.Visible = false;
            this.TxtHourPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHourPrice_KeyPress);
            // 
            // LblHourPrice
            // 
            this.LblHourPrice.AutoSize = true;
            this.LblHourPrice.Location = new System.Drawing.Point(545, 111);
            this.LblHourPrice.Name = "LblHourPrice";
            this.LblHourPrice.Size = new System.Drawing.Size(101, 13);
            this.LblHourPrice.TabIndex = 20;
            this.LblHourPrice.Text = "Custo da Hora (R$):";
            this.LblHourPrice.Visible = false;
            // 
            // ChbActive
            // 
            this.ChbActive.AutoSize = true;
            this.ChbActive.Checked = true;
            this.ChbActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChbActive.Location = new System.Drawing.Point(396, 129);
            this.ChbActive.Name = "ChbActive";
            this.ChbActive.Size = new System.Drawing.Size(50, 17);
            this.ChbActive.TabIndex = 19;
            this.ChbActive.Text = "Ativo";
            this.ChbActive.UseVisualStyleBackColor = true;
            // 
            // BtnEditar_Consulta
            // 
            this.BtnEditar_Consulta.Location = new System.Drawing.Point(464, 382);
            this.BtnEditar_Consulta.Name = "BtnEditar_Consulta";
            this.BtnEditar_Consulta.Size = new System.Drawing.Size(88, 23);
            this.BtnEditar_Consulta.TabIndex = 18;
            this.BtnEditar_Consulta.Text = "Editar";
            this.BtnEditar_Consulta.UseVisualStyleBackColor = true;
            this.BtnEditar_Consulta.Click += new System.EventHandler(this.BtnEditar_Consulta_Click);
            // 
            // BtnExcluir_Consulta
            // 
            this.BtnExcluir_Consulta.Location = new System.Drawing.Point(558, 382);
            this.BtnExcluir_Consulta.Name = "BtnExcluir_Consulta";
            this.BtnExcluir_Consulta.Size = new System.Drawing.Size(88, 23);
            this.BtnExcluir_Consulta.TabIndex = 17;
            this.BtnExcluir_Consulta.Text = "Excluir";
            this.BtnExcluir_Consulta.UseVisualStyleBackColor = true;
            this.BtnExcluir_Consulta.Click += new System.EventHandler(this.BtnExcluir_Consulta_Click);
            // 
            // BtnCancelar_Consulta
            // 
            this.BtnCancelar_Consulta.Location = new System.Drawing.Point(464, 183);
            this.BtnCancelar_Consulta.Name = "BtnCancelar_Consulta";
            this.BtnCancelar_Consulta.Size = new System.Drawing.Size(88, 23);
            this.BtnCancelar_Consulta.TabIndex = 16;
            this.BtnCancelar_Consulta.Text = "Cancelar";
            this.BtnCancelar_Consulta.UseVisualStyleBackColor = true;
            this.BtnCancelar_Consulta.Click += new System.EventHandler(this.BtnCancelar_Consulta_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(558, 183);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(88, 23);
            this.BtnSave.TabIndex = 15;
            this.BtnSave.Text = "Salvar";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TxtIdUsuario
            // 
            this.TxtIdUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.TxtIdUsuario.Enabled = false;
            this.TxtIdUsuario.Location = new System.Drawing.Point(85, 6);
            this.TxtIdUsuario.Name = "TxtIdUsuario";
            this.TxtIdUsuario.Size = new System.Drawing.Size(97, 20);
            this.TxtIdUsuario.TabIndex = 14;
            this.TxtIdUsuario.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Id do Usuário:";
            this.label6.Visible = false;
            // 
            // CbbUserType
            // 
            this.CbbUserType.Location = new System.Drawing.Point(6, 128);
            this.CbbUserType.Name = "CbbUserType";
            this.CbbUserType.Size = new System.Drawing.Size(250, 21);
            this.CbbUserType.TabIndex = 10;
            this.CbbUserType.SelectedIndexChanged += new System.EventHandler(this.CbbUserType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tipo de Usuário *:";
            // 
            // TxtPass
            // 
            this.TxtPass.Location = new System.Drawing.Point(396, 88);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.Size = new System.Drawing.Size(250, 20);
            this.TxtPass.TabIndex = 8;
            this.TxtPass.UseSystemPasswordChar = true;
            // 
            // TxtLogin
            // 
            this.TxtLogin.Location = new System.Drawing.Point(396, 49);
            this.TxtLogin.Name = "TxtLogin";
            this.TxtLogin.Size = new System.Drawing.Size(250, 20);
            this.TxtLogin.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(393, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Senha *:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Login *:";
            // 
            // TxtCPF
            // 
            this.TxtCPF.Location = new System.Drawing.Point(6, 88);
            this.TxtCPF.Name = "TxtCPF";
            this.TxtCPF.Size = new System.Drawing.Size(250, 20);
            this.TxtCPF.TabIndex = 4;
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(6, 49);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(250, 20);
            this.TxtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CPF *:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome *:";
            // 
            // DtgUsers
            // 
            this.DtgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgUsers.Location = new System.Drawing.Point(6, 226);
            this.DtgUsers.MultiSelect = false;
            this.DtgUsers.Name = "DtgUsers";
            this.DtgUsers.ReadOnly = true;
            this.DtgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgUsers.Size = new System.Drawing.Size(640, 150);
            this.DtgUsers.TabIndex = 0;
            // 
            // LblExit
            // 
            this.LblExit.AutoSize = true;
            this.LblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblExit.Location = new System.Drawing.Point(636, 9);
            this.LblExit.Name = "LblExit";
            this.LblExit.Size = new System.Drawing.Size(32, 16);
            this.LblExit.TabIndex = 1;
            this.LblExit.Text = "Sair";
            this.LblExit.Click += new System.EventHandler(this.LblExit_Click);
            // 
            // LblOla
            // 
            this.LblOla.AutoSize = true;
            this.LblOla.Location = new System.Drawing.Point(9, 12);
            this.LblOla.Name = "LblOla";
            this.LblOla.Size = new System.Drawing.Size(26, 13);
            this.LblOla.TabIndex = 2;
            this.LblOla.Text = "Olá,";
            // 
            // FrmLoggedAdminIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 511);
            this.Controls.Add(this.LblOla);
            this.Controls.Add(this.LblExit);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmLoggedAdminIndex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SUEP - Admin";
            this.Load += new System.EventHandler(this.FrmLoggedAdminIndex_Load);
            this.tabControl1.ResumeLayout(false);
            this.TbpUser.ResumeLayout(false);
            this.TbpUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TbpUser;
        private System.Windows.Forms.TextBox TxtCPF;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DtgUsers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtPass;
        private System.Windows.Forms.TextBox TxtLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CbbUserType;
        private System.Windows.Forms.TextBox TxtIdUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnCancelar_Consulta;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnEditar_Consulta;
        private System.Windows.Forms.Button BtnExcluir_Consulta;
        private System.Windows.Forms.CheckBox ChbActive;
        private System.Windows.Forms.Label LblExit;
        private System.Windows.Forms.TextBox TxtHourPrice;
        private System.Windows.Forms.Label LblHourPrice;
        private System.Windows.Forms.Label LblOla;
    }
}