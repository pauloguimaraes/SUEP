using System;
using System.Collections.Generic;
using USP.ESI.SUEP.Dao;
using USP.ESI.SUEP.Lib.Model;

namespace USP.ESI.SUEP.Lib.Controller
{
    public class UserController
    {
        public List<User> Get()
        {
            var _objLstDatabaseUsers = new UserDAO().Get();
            var _objLstUsers = new List<User>();

            foreach (var _objDatabaseUser in _objLstDatabaseUsers)
                _objLstUsers.Add(DaoToModel(_objDatabaseUser));

            return _objLstUsers;
        }

        public List<string> GetAllPacientsName()
        {
            var _objLstDatabaseUsers = new UserDAO().GetAllPacients();
            var _objLstUsers = new List<string>();

            foreach (var _objDatabaseUser in _objLstDatabaseUsers)
                _objLstUsers.Add(_objDatabaseUser.Name);

            return _objLstUsers;
        }

        private User DaoToModel(TbSuep_User _parObjDatabaseUser)
        {
            try
            {
                return new User(
                    _parObjDatabaseUser.Login,
                    _parObjDatabaseUser.Pass,
                    _parObjDatabaseUser.TbSuep_User_Type.UserType)
                {
                    Id = _parObjDatabaseUser.Id,
                    Name = _parObjDatabaseUser.Name,
                    CPF = _parObjDatabaseUser.CPF
                };
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }
    }
}
