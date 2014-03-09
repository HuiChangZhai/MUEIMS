using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnterpriseSystemASPX.Models;

namespace EnterpriseSystemASPX.DAL
{
    [Serializable]
    public class DALMEnterpriseAdmin
    {
        public MEnterpriseAdmin GetMEnterpriseAdmin(int adminID)
        {
            EMSEntities entity = new EMSEntities();
            MEnterpriseAdmin admin = entity.MEnterpriseAdmin.SingleOrDefault(m => (m.MEnterpriseAdminID == adminID));

            return admin;
        }

        public MEnterpriseAdmin GetMEnterpriseAdmin(string adminName)
        {
            EMSEntities entity = new EMSEntities();
            MEnterpriseAdmin admin = entity.MEnterpriseAdmin.SingleOrDefault(m => (m.AdminName.ToString() == adminName));

            return admin;
        }

        public MEnterpriseAdmin GetMEnterpriseAdmin(string adminName, string password)
        {
            EMSEntities entity = new EMSEntities();
            MEnterpriseAdmin admin =  entity.MEnterpriseAdmin.SingleOrDefault(m => m.AdminName == adminName && m.MEnterpriseAdminPassword == password );

            return admin;
        }
    }
}