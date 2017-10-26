using System;
using System.Data.Entity;
using System.Linq;

namespace USP.ESI.SUEP.Dao
{
    public class LoginDAO
    {
        private EntidadesContext _objContext;

        public LoginDAO(EntidadesContext _par_objContext)
        {
            _objContext = _par_objContext;
        }

        public TbSuep_User Auth(string _parStrLogin, string _parStrPass)
        {
            try
            {
                var _objUser = _objContext.Users.Include(x => x.TbSuep_User_Type).FirstOrDefault(user => user.Login.Equals(_parStrLogin) && user.Pass.Equals(_parStrPass));

                if (_objUser == null)
                    throw new Exception("Usuário inexistente!");

                return _objUser;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
