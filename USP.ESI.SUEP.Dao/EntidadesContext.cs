using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USP.ESI.SUEP.Dao
{
    public class EntidadesContext : DbContext
    {
        public EntidadesContext() : base("name=SUEPEntities")
        {             
        }

        public virtual DbSet<TbSuep_User> Users { get; set; }
    }
}
