using System;

namespace USP.ESI.SUEP.Lib.Model
{
    public class Agenda
    {
        public int Id { get; set; }
        public DateTime DtBegin { get; set; }
        public DateTime DtEnd { get; set; }
        public User Doctor { get; set; }
        public User Pacient { get; set; }
    }
}
