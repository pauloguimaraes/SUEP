using System.Collections.Generic;
using System.Data.Entity;

namespace USP.ESI.SUEP.Dao
{
    public class EntidadesContext : DbContext
    {
        public EntidadesContext() : base("name=SUEPEntities")
        {             
        }

        public virtual DbSet<TbSuep_User> Users { get; set; }
        public virtual DbSet<TbSuep_User_Type> UserTypes { get; set; }
        public virtual DbSet<TbSuep_Agenda> Agendas { get; set; }
    }
}
