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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TbpUser = new System.Windows.Forms.TabPage();
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
            this.tabControl1.SuspendLayout();
            this.TbpUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TbpUser);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // TbpUser
            // 
            this.TbpUser.BackColor = System.Drawing.SystemColors.Control;
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
            // CbbUserType
            // 
            this.CbbUserType.Location = new System.Drawing.Point(396, 114);
            this.CbbUserType.Name = "CbbUserType";
            this.CbbUserType.Size = new System.Drawing.Size(250, 21);
            this.CbbUserType.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(393, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tipo de Usuário:";
            // 
            // TxtPass
            // 
            this.TxtPass.Location = new System.Drawing.Point(396, 74);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.Size = new System.Drawing.Size(250, 20);
            this.TxtPass.TabIndex = 8;
            // 
            // TxtLogin
            // 
            this.TxtLogin.Location = new System.Drawing.Point(396, 35);
            this.TxtLogin.Name = "TxtLogin";
            this.TxtLogin.Size = new System.Drawing.Size(250, 20);
            this.TxtLogin.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(393, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Senha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Login:";
            // 
            // TxtCPF
            // 
            this.TxtCPF.Location = new System.Drawing.Point(6, 74);
            this.TxtCPF.Name = "TxtCPF";
            this.TxtCPF.Size = new System.Drawing.Size(250, 20);
            this.TxtCPF.TabIndex = 4;
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(6, 35);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(250, 20);
            this.TxtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CPF:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome:";
            // 
            // DtgUsers
            // 
            this.DtgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgUsers.Location = new System.Drawing.Point(6, 255);
            this.DtgUsers.MultiSelect = false;
            this.DtgUsers.Name = "DtgUsers";
            this.DtgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgUsers.Size = new System.Drawing.Size(640, 150);
            this.DtgUsers.TabIndex = 0;
            this.DtgUsers.SelectionChanged += new System.EventHandler(DtgUsers_SelectionChanged);
            // 
            // FrmLoggedAdminIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
    }
}