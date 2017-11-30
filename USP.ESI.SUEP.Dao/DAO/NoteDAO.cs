using System;
using System.Data.Entity;
using System.Linq;

namespace USP.ESI.SUEP.Dao.DAO
{
    public class NoteDAO
    {
        private EntidadesContext _objContext;

        public NoteDAO(EntidadesContext _par_objContext)
        {
            _objContext = _par_objContext;
        }

        public TbSuep_Note Get(int _par_intIdAgenda)
        {
            try
            {
                return _objContext.Notes.Include(x => x.TbSuep_Agenda).FirstOrDefault(note => note.Id_Agenda == _par_intIdAgenda);
            }
            catch(Exception _par_objException)
            {
                throw _par_objException;
            }
        }

        public bool Save(TbSuep_Note _par_objNote)
        {
            try
            {
                var _intIntersectionCount = _objContext.Notes.Where(note => note.Id_Agenda == _par_objNote.Id_Agenda).ToList().Count();

                if(_intIntersectionCount <= 0)
                {
                    _objContext.Notes.Add(_par_objNote);
                    _objContext.SaveChanges();

                    return true;
                }
                else
                {
                    var _objRetrieved = _objContext.Notes.FirstOrDefault(note => note.Id_Agenda == _par_objNote.Id_Agenda);

                    _objRetrieved.Id_Agenda = _par_objNote.Id_Agenda;
                    _objRetrieved.Note = _par_objNote.Note;

                    _objContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception _par_objException)
            {
                throw _par_objException;
            }
        }
    }
}
