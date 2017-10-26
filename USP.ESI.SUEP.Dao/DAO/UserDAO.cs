using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace USP.ESI.SUEP.Dao
{
    public class UserDAO
    {
        public List<TbSuep_User> Get()
        {
            try
            {
                using (var _objContext = new EntidadesContext())
                {
                    return _objContext.Users.Include(user => user.TbSuep_User_Type).Take(50).OrderBy(user => user.Login).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        public List<TbSuep_User> GetAllPacients()
        {
            try
            {
                using(var _objContext = new EntidadesContext())
                {
                    return _objContext.Users.Include(user => user.TbSuep_User_Type).Where(user => user.Id_User_Type == 3).OrderBy(user => user.Name).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        public bool Delete(TbSuep_User _objDatabaseUser)
        {
            try
            {
                using(var _objContext = new EntidadesContext())
                {
                    var _objRetrieve = _objContext.Users.FirstOrDefault(user => user.Id == _objDatabaseUser.Id);

                    if (_objRetrieve != null)
                    {
                        _objRetrieve.FlActive = false;
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

        public TbSuep_User GetIdFrom(string _parStrUserName)
        {
            try
            {
                using(var _objContext = new EntidadesContext())
                {
                    return _objContext.Users.FirstOrDefault(user => user.Name.Equals(_parStrUserName));
                }
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        public bool Update(TbSuep_User _parObjUserDatabase)
        {
            using (var _objContext = new EntidadesContext())
            {
                var _objRetrieve = _objContext.Users.FirstOrDefault(user => user.Id == _parObjUserDatabase.Id);

                if (_objRetrieve != null)
                {
                    _objRetrieve.Id = _parObjUserDatabase.Id;
                    _objRetrieve.Pass = _parObjUserDatabase.Pass;
                    _objRetrieve.Login = _parObjUserDatabase.Login;
                    _objRetrieve.Id_User_Type = _parObjUserDatabase.Id_User_Type;
                    _objRetrieve.Name = _parObjUserDatabase.Name;
                    _objRetrieve.CPF = _parObjUserDatabase.CPF;
                    _objRetrieve.FlActive = _parObjUserDatabase.FlActive;
                    _objContext.SaveChanges();
                }

                return true;
            }
        }

        public bool Add(TbSuep_User _parObjUserDatabase)
        {
            try
            {
                using(var _objContext = new EntidadesContext())
                {
                    _objContext.Users.Add(_parObjUserDatabase);
                    _objContext.SaveChanges();
                }

                return true;
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }
    }
}
