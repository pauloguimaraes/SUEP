using System;
using System.Text;
using USP.ESI.SUEP.Dao;
using USP.ESI.SUEP.Lib.Model;

namespace USP.ESI.SUEP.Lib.Controller
{
    public class LoginController
    {
        public User Auth(User _parObjUser)
        {
            var _strEncodedPass = Convert.ToBase64String(Encoding.UTF8.GetBytes(_parObjUser.Pass));
            _parObjUser.Pass = _strEncodedPass;

            var _objAuthUser = new LoginDAO(new EntidadesContext()).Auth(_parObjUser.Login, _parObjUser.Pass);

            if (_objAuthUser != null)
                return DaoToModel(_objAuthUser);

            throw new NullReferenceException("Usuario nao registrado no banco de dados");
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
                    Name = _parObjDatabaseUser.Name,
                    CPF = _parObjDatabaseUser.CPF,
                    Id = _parObjDatabaseUser.Id
                };
            }
            catch (Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }
    }
}
