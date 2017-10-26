using System;
using System.Collections.Generic;
using System.Linq;

namespace USP.ESI.SUEP.Dao
{
    public class UserTypeDAO
    {
        private EntidadesContext _objContext;

        public UserTypeDAO(EntidadesContext _par_objContext)
        {
            _objContext = _par_objContext;
        }

        public List<string> Get()
        {
            try
            {
                var _objAllUserTypes = _objContext.UserTypes.ToList();

                if (_objAllUserTypes == null || 
                    _objAllUserTypes.Count == 0)
                    throw new Exception("Lista de tipos de usuário vazia!");

                var _strLstUserTypes = new List<string>();

                foreach (var _objUserType in _objAllUserTypes)
                    _strLstUserTypes.Add(_objUserType.UserType);

                return _strLstUserTypes;
            }
            catch(Exception _par_objException)
            {
                throw _par_objException;
            }
        }
    }
}