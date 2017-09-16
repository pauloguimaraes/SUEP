namespace USP.ESI.SUEP.Dao
{
    public class LoginDAO
    {
        
        public bool Auth(string _parStrLogin, string _parStrPass)
        {
            return _parStrLogin.Equals("adm") && _parStrPass.Equals("123");
        }

    }
}
