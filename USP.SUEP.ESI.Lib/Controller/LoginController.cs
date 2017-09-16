using USP.ESI.SUEP.Dao;
using USP.SUEP.ESI.Lib.Model;

namespace USP.SUEP.ESI.Lib.Controller
{
    public class LoginController
    {

        public bool Auth(User _parObjUser)
        {
            return new LoginDAO().Auth(_parObjUser.Login, _parObjUser.Pass);
        }

    }
}
