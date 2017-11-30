using System;
using USP.ESI.SUEP.Dao;
using USP.ESI.SUEP.Dao.DAO;
using USP.ESI.SUEP.Lib.Model;

namespace USP.ESI.SUEP.Lib.Controller
{
    public class NoteController
    {
        public Note Get(Agenda _par_objAgenda)
        {
            try
            {
                if (_par_objAgenda.Id <= 0)
                    throw new Exception("Nenhuma agenda selecionada");

                var _objDao = new NoteDAO(new EntidadesContext()).Get(_par_objAgenda.Id);

                if (_objDao != null)
                    return DaoToModel(_objDao);
                else
                    return null;
            }
            catch (Exception _par_objException)
            {
                throw _par_objException;
            }
        }

        private Note DaoToModel(TbSuep_Note _par_objDatabaseNote)
        {
            try
            {
                return new Note()
                {
                    Id = _par_objDatabaseNote.Id,
                    Agenda = new Agenda()
                    {
                        Id = _par_objDatabaseNote.Id_Agenda
                    },
                    Annotation = _par_objDatabaseNote.Note
                };
            }
            catch(Exception _par_objException)
            {
                throw _par_objException;
            }
        }

        public bool Save(Note _par_objNote)
        {
            try
            {
                return new NoteDAO(new EntidadesContext()).Save(ModelToDao(_par_objNote));
            }
            catch(Exception _par_objException)
            {
                throw _par_objException;
            }
        }

        private TbSuep_Note ModelToDao(Note _par_objNote)
        {
            try
            {
                return new TbSuep_Note()
                {
                    Id = _par_objNote.Id,
                    Id_Agenda = _par_objNote.Agenda.Id,
                    Note = _par_objNote.Annotation
                };
            }
            catch(Exception _par_objException)
            {
                throw _par_objException;
            }
        }
    }
}
