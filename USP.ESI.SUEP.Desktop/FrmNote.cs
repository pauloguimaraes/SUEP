using System.Windows.Forms;
using USP.ESI.SUEP.Lib.Controller;
using USP.ESI.SUEP.Lib.Model;

namespace USP.ESI.SUEP.Desktop
{
    public partial class FrmNote : Form
    {
        private Agenda agenda;

        public FrmNote(Agenda _par_objAgenda)
        {
            InitializeComponent();

            agenda = _par_objAgenda;

            LblConsulta.Text = "Consulta do(a) paciente " + _par_objAgenda.Pacient.Name + ", iniciando-se às " + _par_objAgenda.DtBegin.ToString("dd/MM/yyyy HH:mm:ss");

            var _objNoteRetrieved = new NoteController().Get(_par_objAgenda);
            if(_objNoteRetrieved != null)
                TxtNote.Text = _objNoteRetrieved.Annotation;
        }

        private void BtnVoltar_Click(object sender, System.EventArgs e)
        {
            Hide();
            FrmAgenda _objFrmAgenda = new FrmAgenda();
            _objFrmAgenda.Show();
        }

        private void BtnSalvar_Click(object sender, System.EventArgs e)
        {
            var _objNote = new Note
            {
                Annotation = TxtNote.Text.Trim(),
                Agenda = agenda
            };

            var _bolSaved = new NoteController().Save(_objNote);

            if(_bolSaved)
                MessageBox.Show("Anotações salvas com sucesso!");
            else
            {
                Clipboard.SetText(TxtNote.Text);
                MessageBox.Show("Infelizmente não foi possível salvar suas anotações, mas as copiamos e você pode colá-las em qualquer lugar.");
            }

                        Hide();
            FrmAgenda _objFrmAgenda = new FrmAgenda();
            _objFrmAgenda.Show();
        }
    }
}
