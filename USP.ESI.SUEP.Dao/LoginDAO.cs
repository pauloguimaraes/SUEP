using System.Data.Entity;
using System.Linq;

namespace USP.ESI.SUEP.Dao
{
    public class LoginDAO
    {
        public TbSuep_User Auth(string _parStrLogin, string _parStrPass)
        {
            using(var _objContext = new EntidadesContext())
            {
                return _objContext.Users.Include(user => user.TbSuep_User_Type).FirstOrDefault(user => user.Login.Equals(_parStrLogin) && user.Pass.Equals(_parStrPass));
            }
        }

    }
}
