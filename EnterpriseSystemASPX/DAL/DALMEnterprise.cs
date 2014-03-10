using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnterpriseSystemASPX.Models;

namespace EnterpriseSystemASPX.DAL
{
    [Serializable]
    public class DALMEnterprise
    {
        public MEnterprise GetMEnterprise()
        {
            EMSEntities entity = new EMSEntities();

            MEnterprise _Menterprise = entity.MEnterprise.First();
            return _Menterprise;
        }
    }
}