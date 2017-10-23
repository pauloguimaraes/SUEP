using USP.ESI.SUEP.Lib.Model.Constants;

namespace USP.ESI.SUEP.Lib.Model
{
    public class Admin : IUserType
    {
        public string GetUserTypeAsString()
        {
            return UserTypeConstants.ADMIN;
        }

        public int GetUserTypeId()
        {
            return 1;
        }
    }
}
