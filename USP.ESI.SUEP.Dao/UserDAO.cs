using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace USP.ESI.SUEP.Dao
{
    public class UserDAO
    {
        public List<TbSuep_User> Get()
        {
            try
            {
                using (var _objContext = new EntidadesContext())
                {
                    return _objContext.Users.Include(user => user.TbSuep_User_Type).Take(50).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        public List<TbSuep_User> GetAllPacients()
        {
            try
            {
                using(var _objContext = new EntidadesContext())
                {
                    return _objContext.Users.Include(user => user.TbSuep_User_Type).Where(user => user.Id_User_Type == 3).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        public TbSuep_User GetIdFrom(string _parStrUserName)
        {
            try
            {
                using(var _objContext = new EntidadesContext())
                {
                    return _objContext.Users.FirstOrDefault(user => user.Name.Equals(_parStrUserName));
                }
            }
            catch(Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }
    }
}
