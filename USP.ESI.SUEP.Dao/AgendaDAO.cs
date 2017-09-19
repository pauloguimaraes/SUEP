using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace USP.ESI.SUEP.Dao
{
    public class AgendaDAO
    {
        public List<TbSuep_Agenda> Get(long _parIntIdUserDoctor)
        {
            try
            {
                using(var _objContext = new EntidadesContext())
                {
                    return _objContext.Agendas.Include(agenda => agenda.TbSuep_User).Include(agenda => agenda.TbSuep_User1).Where(agenda => agenda.Id_User_Doctor == _parIntIdUserDoctor).OrderBy(agenda => agenda.Dt_Begin).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        public void Add(TbSuep_Agenda _parObjDatabaseAgenda)
        {
            try
            {
                using (var _objContext = new EntidadesContext())
                {
                    var _intIntersectionCount = _objContext.Agendas.Where(agenda => (agenda.Dt_Begin <= _parObjDatabaseAgenda.Dt_End && _parObjDatabaseAgenda.Dt_Begin <= agenda.Dt_End) && agenda.Id_User_Doctor == _parObjDatabaseAgenda.Id_User_Doctor).ToList().Count;

                    if(_intIntersectionCount <= 0)
                    {
                        _objContext.Agendas.Add(_parObjDatabaseAgenda);
                        _objContext.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Houve um conflito de horários. Por favor, reveja sua agenda.");
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        public bool Remove(TbSuep_Agenda _objDatabaseAgenda)
        {
            try
            {
                using(var _objContext = new EntidadesContext())
                {
                    var _objRetrieve = _objContext.Agendas.FirstOrDefault(agenda => agenda.Id == _objDatabaseAgenda.Id);

                    if(_objRetrieve != null)
                    {
                        _objContext.Agendas.Remove(_objRetrieve);
                        _objContext.SaveChanges();
                    }

                    return true;
                }
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        public bool Edit(TbSuep_Agenda _parObjDatabaseAgenda)
        {
            try
            {
                using(var _objContext = new EntidadesContext())
                {
                    var _objRetrieved = _objContext.Agendas.FirstOrDefault(agenda => agenda.Id == _parObjDatabaseAgenda.Id);

                    if(_objRetrieved != null)
                    {
                        _objRetrieved.Id_User_Doctor = _parObjDatabaseAgenda.Id_User_Doctor;
                        _objRetrieved.Id_User_Pacient = _parObjDatabaseAgenda.Id_User_Pacient;
                        _objRetrieved.Dt_Begin = _parObjDatabaseAgenda.Dt_Begin;
                        _objRetrieved.Dt_End = _parObjDatabaseAgenda.Dt_End;

                        _objContext.SaveChanges();
                    }
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }
    }
}
