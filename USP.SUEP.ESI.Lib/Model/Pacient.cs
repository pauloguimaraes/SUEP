using USP.ESI.SUEP.Lib.Model.Constants;

namespace USP.ESI.SUEP.Lib.Model
{
    public class Pacient : IUserType
    {
        public string GetUserTypeAsString()
        {
            return UserTypeConstants.PACIE;
        }

        public int GetUserTypeId()
        {
            return 3;
        }
    }
}
