using System.Collections.Generic;
using USP.ESI.SUEP.Dao;

namespace USP.ESI.SUEP.Lib.Controller
{
    public class UserTypeController
    {
        public List<string> Get()
        {
            return new UserTypeDAO().Get();
        }
    }
}
