using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace USP.ESI.SUEP.Dao
{
    public class AgendaDAO
    {
        private EntidadesContext _objContext;

        public AgendaDAO(EntidadesContext _par_objContext)
        {
            _objContext = _par_objContext;
        }

        public List<TbSuep_Agenda> Get(long _parIntIdUserDoctor)
        {
            try
            {
                var _objAgenda = _objContext.Agendas.Include(agenda => agenda.TbSuep_User).Include(agenda => agenda.TbSuep_User1).Where(agenda => agenda.Id_User_Doctor == _parIntIdUserDoctor).OrderBy(agenda => agenda.Dt_Begin).ToList();

                if (_objAgenda == null || _objAgenda.Count == 0)
                    throw new Exception("Médico não possui agenda");

                return _objAgenda;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Add(TbSuep_Agenda _parObjDatabaseAgenda)
        {
            try
            {
                var _intIntersectionCount = _objContext.Agendas.Where(agenda => 
                    (agenda.Dt_Begin <= _parObjDatabaseAgenda.Dt_End && 
                        _parObjDatabaseAgenda.Dt_Begin <= agenda.Dt_End) && 
                        agenda.Id_User_Doctor == _parObjDatabaseAgenda.Id_User_Doctor).ToList().Count;

                if(_intIntersectionCount <= 0)
                {
                    _objContext.Agendas.Add(_parObjDatabaseAgenda);
                    _objContext.SaveChanges();

                    return true;
                }
                else
                {
                    throw new Exception("Houve um conflito de horários. Por favor, reveja sua agenda.");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Remove(TbSuep_Agenda _objDatabaseAgenda)
        {
            try
            {
                var _objRetrieve = _objContext.Agendas.FirstOrDefault(agenda => agenda.Id == _objDatabaseAgenda.Id);
                
                if(_objRetrieve != null)
                {
                    if (_objRetrieve.Dt_End < DateTime.Now)
                        throw new Exception("Não é possível excluir agendas já acontecidas");
                    
                    _objContext.Agendas.Remove(_objRetrieve);
                    _objContext.SaveChanges();
                }

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Edit(TbSuep_Agenda _parObjDatabaseAgenda)
        {
            try
            {
                var _intIntersectionCount = _objContext.Agendas.Where(agenda =>
                    (agenda.Dt_Begin <= _parObjDatabaseAgenda.Dt_End && 
                        _parObjDatabaseAgenda.Dt_Begin <= agenda.Dt_End) && 
                        agenda.Id_User_Doctor == _parObjDatabaseAgenda.Id_User_Doctor && 
                        agenda.Id != _parObjDatabaseAgenda.Id).ToList().Count;

                if (_intIntersectionCount <= 0)
                {
                    var _objRetrieved = _objContext.Agendas.FirstOrDefault(agenda => agenda.Id == _parObjDatabaseAgenda.Id);

                    if (_objRetrieved != null)
                    {
                        _objRetrieved.Id_User_Doctor = _parObjDatabaseAgenda.Id_User_Doctor;
                        _objRetrieved.Id_User_Pacient = _parObjDatabaseAgenda.Id_User_Pacient;
                        _objRetrieved.Dt_Begin = _parObjDatabaseAgenda.Dt_Begin;
                        _objRetrieved.Dt_End = _parObjDatabaseAgenda.Dt_End;

                        _objContext.SaveChanges();
                    }
                    return true;
                }
                else
                {
                    throw new Exception("Houve um conflito de horários. Por favor, reveja sua agenda.");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
