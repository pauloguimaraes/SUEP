using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using USP.ESI.SUEP.Desktop.Binding;
using USP.ESI.SUEP.Desktop.SessionInfos;
using USP.ESI.SUEP.Lib;
using USP.ESI.SUEP.Lib.Controller;
using USP.ESI.SUEP.Lib.Model;

namespace USP.ESI.SUEP.Desktop
{
    public partial class Consultas : Form
    {
        private List<string> _lstPacients;

        public Consultas()
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
                        PacientName = _objAgenda.Pacient.Name
                    });
                }

                var _objBinding = new BindingList<BindingAgenda>(_objLstBindingAgendas);
                DtgAgenda.DataSource = _objBinding;

                DtgAgenda.Columns[0].HeaderText = "IDENTIFICAÇÃO";
                DtgAgenda.Columns[1].HeaderText = "INÍCIO DA CONSULTA";
                DtgAgenda.Columns[2].HeaderText = "FINAL DA CONSULTA";
                DtgAgenda.Columns[3].HeaderText = "PACIENTE";
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        private void BtnAddConsult_Click(object sender, EventArgs e)
        {
            try
            {
                if(TxtIdConsulta.Text.Equals(string.Empty))
                {
                    var _objAgenda = new Agenda();
                    _objAgenda.Pacient = new User();
                    _objAgenda.Doctor = new User();
                    _objAgenda.Pacient.Name = TxtPacientsName.Text.ToUpper();
                    _objAgenda.DtBegin = DtpBegin.Value;
                    _objAgenda.DtEnd = DtpBegin.Value.AddMinutes(Convert.ToInt32(TxtSpentTime.Text));
                    _objAgenda.Doctor.Id = LoggedUser.USER.Id;

                    new AgendaController().Add(_objAgenda);
                }
                else
                {
                    var _objAgenda = new Agenda();
                    _objAgenda.Id = Convert.ToInt32(TxtIdConsulta.Text);
                    _objAgenda.Pacient = new User();
                    _objAgenda.Doctor = new User();
                    _objAgenda.Pacient.Name = TxtPacientsName.Text.ToUpper();
                    _objAgenda.DtBegin = DtpBegin.Value;
                    _objAgenda.DtEnd = DtpBegin.Value.AddMinutes(Convert.ToInt32(TxtSpentTime.Text));
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
            var _objCurrentRowAgenda = new Agenda()
            {
                Id = Convert.ToInt32(DtgAgenda.CurrentRow.Cells[0].Value),
                Pacient = new User()
                {
                    Name = DtgAgenda.CurrentRow.Cells[3].Value.ToString()
                },
                DtBegin = Convert.ToDateTime(DtgAgenda.CurrentRow.Cells[1].Value),
            };

            var _objTimeSpan = Convert.ToDateTime(DtgAgenda.CurrentRow.Cells[1].Value).Subtract(Convert.ToDateTime(DtgAgenda.CurrentRow.Cells[2].Value));

            TxtIdConsulta.Text = _objCurrentRowAgenda.Id.ToString();
            TxtPacientsName.Text = _objCurrentRowAgenda.Pacient.Name;
            TxtSpentTime.Text = _objTimeSpan.Hours < 0 ? Math.Abs(_objTimeSpan.Hours * 60).ToString() : Math.Abs(_objTimeSpan.Minutes).ToString();
            DtpBegin.Value = _objCurrentRowAgenda.DtBegin;
        }

        private void BtnCancelar_Consulta_Click(object sender, EventArgs e)
        {
            LimparTela();
        }

        private void LimparTela()
        {
            TxtIdConsulta.Text =
                            TxtPacientsName.Text =
                            TxtSpentTime.Text = string.Empty;
        }
    }
}
