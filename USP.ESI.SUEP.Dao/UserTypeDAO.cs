using System;
using System.Collections.Generic;
using System.Linq;

namespace USP.ESI.SUEP.Dao
{
    public class UserTypeDAO
    {
        private EntidadesContext _objContext;

        public UserTypeDAO()
        {
            _objContext = new EntidadesContext();
        }

        public List<string> Get()
        {
            var _objAllUserTypes = _objContext.UserTypes.ToList();
            var _strLstUserTypes = new List<string>();

            foreach (var _objUserType in _objAllUserTypes)
                _strLstUserTypes.Add(_objUserType.UserType);

            return _strLstUserTypes;
        }
    }
}