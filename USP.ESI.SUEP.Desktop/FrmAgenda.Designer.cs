namespace USP.ESI.SUEP.Desktop
{
    partial class FrmAgenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgenda));
            this.TbcAgenda = new System.Windows.Forms.TabControl();
            this.TbpAgenda = new System.Windows.Forms.TabPage();
            this.ChbPaga = new System.Windows.Forms.CheckBox();
            this.TxtPreco = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnIniciarConsulta = new System.Windows.Forms.Button();
            this.BtnCancelar_Consulta = new System.Windows.Forms.Button();
            this.TxtIdConsulta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnEditar_Consulta = new System.Windows.Forms.Button();
            this.BtnExcluir_Consulta = new System.Windows.Forms.Button();
            this.BtnAddConsult = new System.Windows.Forms.Button();
            this.TxtSpentTime = new System.Windows.Forms.TextBox();
            this.TxtPacientsName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpBegin = new System.Windows.Forms.DateTimePicker();
            this.DtgAgenda = new System.Windows.Forms.DataGridView();
            this.LblExit = new System.Windows.Forms.Label();
            this.TbcAgenda.SuspendLayout();
            this.TbpAgenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgAgenda)).BeginInit();
            this.SuspendLayout();
            // 
            // TbcAgenda
            // 
            this.TbcAgenda.Controls.Add(this.TbpAgenda);
            this.TbcAgenda.Location = new System.Drawing.Point(12, 62);
            this.TbcAgenda.Name = "TbcAgenda";
            this.TbcAgenda.SelectedIndex = 0;
            this.TbcAgenda.Size = new System.Drawing.Size(660, 437);
            this.TbcAgenda.TabIndex = 1;
            // 
            // TbpAgenda
            // 
            this.TbpAgenda.BackColor = System.Drawing.SystemColors.Control;
            this.TbpAgenda.Controls.Add(this.ChbPaga);
            this.TbpAgenda.Controls.Add(this.TxtPreco);
            this.TbpAgenda.Controls.Add(this.label5);
            this.TbpAgenda.Controls.Add(this.BtnIniciarConsulta);
            this.TbpAgenda.Controls.Add(this.BtnCancelar_Consulta);
            this.TbpAgenda.Controls.Add(this.TxtIdConsulta);
            this.TbpAgenda.Controls.Add(this.label4);
            this.TbpAgenda.Controls.Add(this.BtnEditar_Consulta);
            this.TbpAgenda.Controls.Add(this.BtnExcluir_Consulta);
            this.TbpAgenda.Controls.Add(this.BtnAddConsult);
            this.TbpAgenda.Controls.Add(this.TxtSpentTime);
            this.TbpAgenda.Controls.Add(this.TxtPacientsName);
            this.TbpAgenda.Controls.Add(this.label3);
            this.TbpAgenda.Controls.Add(this.label2);
            this.TbpAgenda.Controls.Add(this.label1);
            this.TbpAgenda.Controls.Add(this.DtpBegin);
            this.TbpAgenda.Controls.Add(this.DtgAgenda);
            this.TbpAgenda.Location = new System.Drawing.Point(4, 22);
            this.TbpAgenda.Name = "TbpAgenda";
            this.TbpAgenda.Padding = new System.Windows.Forms.Padding(3);
            this.TbpAgenda.Size = new System.Drawing.Size(652, 411);
            this.TbpAgenda.TabIndex = 0;
            this.TbpAgenda.Text = "Consultas";
            // 
            // ChbPaga
            // 
            this.ChbPaga.AutoSize = true;
            this.ChbPaga.Location = new System.Drawing.Point(70, 112);
            this.ChbPaga.Name = "ChbPaga";
            this.ChbPaga.Size = new System.Drawing.Size(51, 17);
            this.ChbPaga.TabIndex = 17;
            this.ChbPaga.Text = "Paga";
            this.ChbPaga.UseVisualStyleBackColor = true;
            // 
            // TxtPreco
            // 
            this.TxtPreco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtPreco.Location = new System.Drawing.Point(474, 75);
            this.TxtPreco.Name = "TxtPreco";
            this.TxtPreco.Size = new System.Drawing.Size(88, 20);
            this.TxtPreco.TabIndex = 16;
            this.TxtPreco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPreco_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Preço:";
            // 
            // BtnIniciarConsulta
            // 
            this.BtnIniciarConsulta.Location = new System.Drawing.Point(539, 382);
            this.BtnIniciarConsulta.Name = "BtnIniciarConsulta";
            this.BtnIniciarConsulta.Size = new System.Drawing.Size(107, 23);
            this.BtnIniciarConsulta.TabIndex = 14;
            this.BtnIniciarConsulta.Text = "Iniciar consulta!";
            this.BtnIniciarConsulta.UseVisualStyleBackColor = true;
            this.BtnIniciarConsulta.Click += new System.EventHandler(this.BtnIniciarConsulta_Click);
            // 
            // BtnCancelar_Consulta
            // 
            this.BtnCancelar_Consulta.Location = new System.Drawing.Point(66, 174);
            this.BtnCancelar_Consulta.Name = "BtnCancelar_Consulta";
            this.BtnCancelar_Consulta.Size = new System.Drawing.Size(88, 23);
            this.BtnCancelar_Consulta.TabIndex = 13;
            this.BtnCancelar_Consulta.Text = "Cancelar";
            this.BtnCancelar_Consulta.UseVisualStyleBackColor = true;
            this.BtnCancelar_Consulta.Click += new System.EventHandler(this.BtnCancelar_Consulta_Click);
            // 
            // TxtIdConsulta
            // 
            this.TxtIdConsulta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.TxtIdConsulta.Enabled = false;
            this.TxtIdConsulta.Location = new System.Drawing.Point(549, 6);
            this.TxtIdConsulta.Name = "TxtIdConsulta";
            this.TxtIdConsulta.Size = new System.Drawing.Size(97, 20);
            this.TxtIdConsulta.TabIndex = 12;
            this.TxtIdConsulta.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(465, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Id da Consulta:";
            this.label4.Visible = false;
            // 
            // BtnEditar_Consulta
            // 
            this.BtnEditar_Consulta.Location = new System.Drawing.Point(6, 382);
            this.BtnEditar_Consulta.Name = "BtnEditar_Consulta";
            this.BtnEditar_Consulta.Size = new System.Drawing.Size(88, 23);
            this.BtnEditar_Consulta.TabIndex = 10;
            this.BtnEditar_Consulta.Text = "Editar";
            this.BtnEditar_Consulta.UseVisualStyleBackColor = true;
            this.BtnEditar_Consulta.Click += new System.EventHandler(this.BtnEditar_Consulta_Click);
            // 
            // BtnExcluir_Consulta
            // 
            this.BtnExcluir_Consulta.Location = new System.Drawing.Point(100, 382);
            this.BtnExcluir_Consulta.Name = "BtnExcluir_Consulta";
            this.BtnExcluir_Consulta.Size = new System.Drawing.Size(88, 23);
            this.BtnExcluir_Consulta.TabIndex = 9;
            this.BtnExcluir_Consulta.Text = "Excluir";
            this.BtnExcluir_Consulta.UseVisualStyleBackColor = true;
            this.BtnExcluir_Consulta.Click += new System.EventHandler(this.BtnExcluir_Consulta_Click);
            // 
            // BtnAddConsult
            // 
            this.BtnAddConsult.Location = new System.Drawing.Point(160, 174);
            this.BtnAddConsult.Name = "BtnAddConsult";
            this.BtnAddConsult.Size = new System.Drawing.Size(88, 23);
            this.BtnAddConsult.TabIndex = 8;
            this.BtnAddConsult.Text = "Salvar";
            this.BtnAddConsult.UseVisualStyleBackColor = true;
            this.BtnAddConsult.Click += new System.EventHandler(this.BtnAddConsult_Click);
            // 
            // TxtSpentTime
            // 
            this.TxtSpentTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtSpentTime.Location = new System.Drawing.Point(339, 75);
            this.TxtSpentTime.Name = "TxtSpentTime";
            this.TxtSpentTime.Size = new System.Drawing.Size(88, 20);
            this.TxtSpentTime.TabIndex = 7;
            this.TxtSpentTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSpentTime_KeyPress);
            // 
            // TxtPacientsName
            // 
            this.TxtPacientsName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.TxtPacientsName.Location = new System.Drawing.Point(66, 32);
            this.TxtPacientsName.Name = "TxtPacientsName";
            this.TxtPacientsName.Size = new System.Drawing.Size(496, 20);
            this.TxtPacientsName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nome do Paciente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Duração:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Início da Consulta:";
            // 
            // DtpBegin
            // 
            this.DtpBegin.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpBegin.Location = new System.Drawing.Point(66, 75);
            this.DtpBegin.Name = "DtpBegin";
            this.DtpBegin.Size = new System.Drawing.Size(232, 20);
            this.DtpBegin.TabIndex = 1;
            // 
            // DtgAgenda
            // 
            this.DtgAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgAgenda.Location = new System.Drawing.Point(6, 226);
            this.DtgAgenda.MultiSelect = false;
            this.DtgAgenda.Name = "DtgAgenda";
            this.DtgAgenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgAgenda.Size = new System.Drawing.Size(640, 150);
            this.DtgAgenda.TabIndex = 0;
            // 
            // LblExit
            // 
            this.LblExit.AutoSize = true;
            this.LblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblExit.Location = new System.Drawing.Point(636, 9);
            this.LblExit.Name = "LblExit";
            this.LblExit.Size = new System.Drawing.Size(32, 16);
            this.LblExit.TabIndex = 2;
            this.LblExit.Text = "Sair";
            this.LblExit.Click += new System.EventHandler(this.LblExit_Click);
            // 
            // FrmAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 511);
            this.Controls.Add(this.LblExit);
            this.Controls.Add(this.TbcAgenda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAgenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultas";
            this.Load += new System.EventHandler(this.FrmAgenda_Load);
            this.TbcAgenda.ResumeLayout(false);
            this.TbpAgenda.ResumeLayout(false);
            this.TbpAgenda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgAgenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TbcAgenda;
        private System.Windows.Forms.TabPage TbpAgenda;
        private System.Windows.Forms.DateTimePicker DtpBegin;
        private System.Windows.Forms.DataGridView DtgAgenda;
        private System.Windows.Forms.TextBox TxtPacientsName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSpentTime;
        private System.Windows.Forms.Button BtnAddConsult;
        private System.Windows.Forms.Button BtnEditar_Consulta;
        private System.Windows.Forms.Button BtnExcluir_Consulta;
        private System.Windows.Forms.TextBox TxtIdConsulta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnCancelar_Consulta;
        private System.Windows.Forms.Label LblExit;
        private System.Windows.Forms.Button BtnIniciarConsulta;
        private System.Windows.Forms.CheckBox ChbPaga;
        private System.Windows.Forms.TextBox TxtPreco;
        private System.Windows.Forms.Label label5;
    }
}