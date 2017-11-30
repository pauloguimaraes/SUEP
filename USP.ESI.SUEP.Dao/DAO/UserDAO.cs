using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace USP.ESI.SUEP.Dao
{
    public class UserDAO
    {
        private EntidadesContext entidadesContext;

        public UserDAO(EntidadesContext _par_objEntidadesContext)
        {
            entidadesContext = _par_objEntidadesContext;
        }

        public List<TbSuep_User> Get(long _par_intIdLoggedUser)
        {
            try
            {
                var _objUsers = entidadesContext.Users.Include(user => user.TbSuep_User_Type);

                if (_objUsers == null || _objUsers.Count() == 0)
                    throw new Exception("Não existem usuários cadastrados!");

                return _objUsers.Take(50).Where(user => user.Id != _par_intIdLoggedUser).OrderBy(user => user.Login).ToList();
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
                return entidadesContext.Users
                    .Include(user => user.TbSuep_User_Type)
                    .Where(user => user.Id_User_Type == 3 && user.FlActive)
                    .OrderBy(user => user.Name)
                    .ToList();
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
                var _objRetrieve = entidadesContext.Users.FirstOrDefault(user => user.Id == _objDatabaseUser.Id);

                if (_objRetrieve != null)
                {
                    _objRetrieve.FlActive = false;
                    entidadesContext.SaveChanges();
                }
                else
                    throw new Exception("Usuário inexistente");

                return true;
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        public TbSuep_User GetUserWithTheName(string _parStrUserName)
        {
            try
            {
                var _objUser = entidadesContext.Users.FirstOrDefault(user => user.Name.Equals(_parStrUserName));

                if (_objUser == null)
                    throw new Exception("Usuário inexistente!");

                return _objUser;
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        public bool Update(TbSuep_User _parObjUserDatabase)
        {
            try
            {
                var _objRetrieve = entidadesContext.Users.FirstOrDefault(user => user.Id == _parObjUserDatabase.Id);

                if (_objRetrieve != null)
                {
                    _objRetrieve.Id = _parObjUserDatabase.Id;
                    _objRetrieve.Pass = _parObjUserDatabase.Pass;
                    _objRetrieve.Login = _parObjUserDatabase.Login;
                    _objRetrieve.Id_User_Type = _parObjUserDatabase.Id_User_Type;
                    _objRetrieve.Name = _parObjUserDatabase.Name;
                    _objRetrieve.HourPrice = _parObjUserDatabase.HourPrice;
                    _objRetrieve.CPF = _parObjUserDatabase.CPF;
                    _objRetrieve.FlActive = _parObjUserDatabase.FlActive;
                    entidadesContext.SaveChanges();
                }
                else
                    throw new Exception("Usuário inexistente!");

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Add(TbSuep_User _parObjUserDatabase)
        {
            try
            {
                if (_parObjUserDatabase.Id > 0)
                    _parObjUserDatabase.Id = 0;

                var _intCount = entidadesContext.Users.Where(user => user.CPF.Equals(_parObjUserDatabase.CPF) || user.Login.Equals(_parObjUserDatabase.Login)).ToList().Count();


                if(_intCount > 0)
                    return false;
                else
                {
                    entidadesContext.Users.Add(_parObjUserDatabase);
                    entidadesContext.SaveChanges();
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
