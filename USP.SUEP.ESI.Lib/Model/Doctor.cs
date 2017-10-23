using USP.ESI.SUEP.Lib.Model.Constants;

namespace USP.ESI.SUEP.Lib.Model
{
    public class Doctor : IUserType
    {
        public string GetUserTypeAsString()
        {
            return UserTypeConstants.DOCTO;
        }

        public int GetUserTypeId()
        {
            return 2;
        }
    }
}
