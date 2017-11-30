using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using USP.ESI.SUEP.Desktop.Binding;
using USP.ESI.SUEP.Desktop.SessionInfos;
using USP.ESI.SUEP.Lib;
using USP.ESI.SUEP.Lib.Controller;
using USP.ESI.SUEP.Lib.Model;

namespace USP.ESI.SUEP.Desktop
{
    public partial class FrmAgenda : Form
    {
        private List<string> _lstPacients;

        public FrmAgenda()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }

        private void FrmAgenda_Load(object sender, EventArgs e)
        {
            _lstPacients = new UserController().GetAllPacientsName();
            var _colPacients = new AutoCompleteStringCollection();
            foreach (var _strPacientName in _lstPacients)
                _colPacients.Add(_strPacientName);

            TxtPacientsName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtPacientsName.AutoCompleteCustomSource = _colPacients;
            
            LoadAgenda();
        }

        private void LoadAgenda()
        {
            try
            {
                DtgAgenda.AutoGenerateColumns = true;
                DtgAgenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                
                var _objLstAgendas = new AgendaController().GetAgendaFrom(LoggedUser.USER);
                var _objLstBindingAgendas = new List<BindingAgenda>();

                foreach(var _objAgenda in _objLstAgendas)
                {
                    _objLstBindingAgendas.Add(new BindingAgenda()
                    {
                        Id = _objAgenda.Id,
                        DtBegin = _objAgenda.DtBegin.ToString("dd/MM/yyyy HH:mm"),
                        DtEnd = _objAgenda.DtEnd.ToString("dd/MM/yyyy HH:mm"),
                        PacientName = _objAgenda.Pacient.Name,
                        Price = (_objAgenda.Price != null) ? _objAgenda.Price.ToString() : string.Empty,
                        Payed = _objAgenda.Payed ? "SIM" : "NÃO"
                    });
                }

                var _objBinding = new BindingList<BindingAgenda>(_objLstBindingAgendas);
                DtgAgenda.DataSource = _objBinding;

                DtgAgenda.Columns[0].HeaderText = "IDENTIFICAÇÃO";
                DtgAgenda.Columns[0].Visible = false;
                DtgAgenda.Columns[1].HeaderText = "INÍCIO DA CONSULTA";
                DtgAgenda.Columns[2].HeaderText = "FINAL DA CONSULTA";
                DtgAgenda.Columns[3].HeaderText = "PACIENTE";
                DtgAgenda.Columns[4].HeaderText = "PREÇO";
                DtgAgenda.Columns[5].HeaderText = "PAGA";
            }
            catch
            {
            }
        }

        private void BtnAddConsult_Click(object sender, EventArgs e)
        {
            try
            {
                var _bolValid = ValidaCampos();

                TxtPreco.Text = TxtPreco.Text.Replace('.', ',');

                if(TxtIdConsulta.Text.Equals(string.Empty))
                {
                    var _objAgenda = new Agenda
                    {
                        Pacient = new User(),
                        Doctor = new User(),
                        DtBegin = DtpBegin.Value,
                        Price = Convert.ToDecimal(TxtPreco.Text),
                        Payed = ChbPaga.Checked,
                        DtEnd = DtpBegin.Value.AddMinutes(Convert.ToInt32(TxtSpentTime.Text))
                    };
                    _objAgenda.Pacient.Name = TxtPacientsName.Text.ToUpper();
                    _objAgenda.Doctor.Id = LoggedUser.USER.Id;

                    new AgendaController().Add(_objAgenda);
                }
                else
                {
                    var _objAgenda = new Agenda
                    {
                        Id = Convert.ToInt32(TxtIdConsulta.Text),
                        Pacient = new User(),
                        Doctor = new User(),
                        DtBegin = DtpBegin.Value,
                        Payed = ChbPaga.Checked,
                        Price = Convert.ToDecimal(TxtPreco.Text),
                        DtEnd = DtpBegin.Value.AddMinutes(Convert.ToInt32(TxtSpentTime.Text))
                    };
                    _objAgenda.Pacient.Name = TxtPacientsName.Text.ToUpper();
                    _objAgenda.Doctor.Id = LoggedUser.USER.Id;
                    
                    new AgendaController().Edit(_objAgenda);
                }

                LimparTela();
                LoadAgenda();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidaCampos()
        {
            var _strMensagem = string.Empty;

            if (TxtPacientsName.Text.Length < 3)
                _strMensagem += "Paciente com nome inválido\n";

            if (TxtSpentTime.Text.Trim().Equals(string.Empty))
                _strMensagem += "Duração inválida\n";

            if (TxtPreco.Text.Trim().Equals(string.Empty) || TxtPreco.Text.Count(s => s == '.') > 1)
                _strMensagem += "Preço inválido\n";

            if (_strMensagem.Equals(string.Empty))
                return true;
            else
                throw new ArgumentException(_strMensagem);
        }

        private void BtnExcluir_Consulta_Click(object sender, EventArgs e)
        {
            var _objCurrentRowId = Convert.ToInt32(DtgAgenda.CurrentRow.Cells[0].Value);

            var _bolCouldBeDeleted = new AgendaController().Remove(new Agenda() { Id = _objCurrentRowId });

            if (_bolCouldBeDeleted)
                MessageBox.Show("Excluído com sucesso!");

            LoadAgenda();
        }

        private void BtnEditar_Consulta_Click(object sender, EventArgs e)
        {
            try
            {
                var _objCurrentRowAgenda = new Agenda()
                {
                    Id = Convert.ToInt32(DtgAgenda.CurrentRow.Cells[0].Value),
                    Pacient = new User()
                    {
                        Name = DtgAgenda.CurrentRow.Cells[3].Value.ToString()
                    },
                    DtBegin = Convert.ToDateTime(DtgAgenda.CurrentRow.Cells[1].Value),
                    Price = Convert.ToDecimal(DtgAgenda.CurrentRow.Cells[4].Value.ToString().Equals(string.Empty) ? 0 : DtgAgenda.CurrentRow.Cells[4].Value),
                    Payed = DtgAgenda.CurrentRow.Cells[5].Value.ToString().ToUpper().Equals("SIM")
                };

                var _objTimeSpan = Convert.ToDateTime(DtgAgenda.CurrentRow.Cells[1].Value).Subtract(Convert.ToDateTime(DtgAgenda.CurrentRow.Cells[2].Value));

                TxtIdConsulta.Text = _objCurrentRowAgenda.Id.ToString();
                TxtPacientsName.Text = _objCurrentRowAgenda.Pacient.Name;
                TxtSpentTime.Text = _objTimeSpan.Hours < 0 ? Math.Abs(_objTimeSpan.Hours * 60).ToString() : Math.Abs(_objTimeSpan.Minutes).ToString();
                DtpBegin.Value = _objCurrentRowAgenda.DtBegin;
                TxtPreco.Text = _objCurrentRowAgenda.Price.ToString();
                ChbPaga.Checked = _objCurrentRowAgenda.Payed;
            }
            catch
            {

            }
        }

        private void BtnCancelar_Consulta_Click(object sender, EventArgs e)
        {
            LimparTela();

            _lstPacients = new UserController().GetAllPacientsName();
            var _colPacients = new AutoCompleteStringCollection();
            foreach (var _strPacientName in _lstPacients)
                _colPacients.Add(_strPacientName);

            TxtPacientsName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtPacientsName.AutoCompleteCustomSource = _colPacients;
        }

        private void LimparTela()
        {
            TxtIdConsulta.Text =
                TxtPacientsName.Text =
                TxtPreco.Text =
                TxtSpentTime.Text = string.Empty;
            ChbPaga.Checked = false;
        }

        private void LblExit_Click(object sender, EventArgs e)
        {
            LoggedUser.USER = null;

            Hide();
            new FrmLogin().Show();
        }

        private void BtnIniciarConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                var _objCurrentRowAgenda = new Agenda()
                {
                    Id = Convert.ToInt32(DtgAgenda.CurrentRow.Cells[0].Value),
                    Pacient = new User()
                    {
                        Name = DtgAgenda.CurrentRow.Cells[3].Value.ToString()
                    },
                    DtBegin = Convert.ToDateTime(DtgAgenda.CurrentRow.Cells[1].Value),
                };

                Hide();
                FrmNote _objFrmNote = new FrmNote(_objCurrentRowAgenda);
                _objFrmNote.Show();
            }
            catch
            {
            }
        }

        private void TxtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void TxtSpentTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                return;
            }
        }
    }
}
