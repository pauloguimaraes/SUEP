namespace USP.SUEP.ESI.Lib.Model
{
    public class User
    {
        public string Login { get; set; }
        public string Pass { get; set; }

        public User(string login, string pass)
        {
            Login = login;
            Pass = pass;
        }
    }
}
