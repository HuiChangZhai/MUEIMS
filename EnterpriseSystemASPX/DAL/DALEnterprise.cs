using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnterpriseSystemASPX.Models;

namespace EnterpriseSystemASPX.DAL
{
    [Serializable]
    public class DALEnterprise
    {
        public Enterprise GetEnterprise(int enterpriseid)
        {
            EMSEntities entity = new EMSEntities();
            Enterprise enterprise = entity.Enterprise.SingleOrDefault(m => m.EnterpriseID == enterpriseid);

            return enterprise;
        }

        public Enterprise GetEnterprise(string enterprisename)
        {
            EMSEntities entity = new EMSEntities();
            Enterprise enterprise = entity.Enterprise.SingleOrDefault(m => m.EnterpriseName == enterprisename);

            return enterprise;
        }
    }
}