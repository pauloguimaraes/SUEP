namespace USP.ESI.SUEP.Desktop.Binding
{
    public class BindingUser
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Tipo_Usuario { get; set; }
        public int IdUserType { get; set; }
        public bool IsActive { get; set; }
        public string Ativo { get; set; }
    }
}
