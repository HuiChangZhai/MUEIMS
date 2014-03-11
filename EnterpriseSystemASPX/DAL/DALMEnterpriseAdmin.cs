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
            MEnterpriseAdmin admin = entity.MEnterpriseAdmin.SingleOrDefault(m => (m.AdminName == adminName));

            return admin;
        }

        public MEnterpriseAdmin GetMEnterpriseAdmin(string adminName, string password)
        {
            EMSEntities entity = new EMSEntities();
            MEnterpriseAdmin admin =  entity.MEnterpriseAdmin.SingleOrDefault(m => m.AdminName == adminName && m.MEnterpriseAdminPassword == password );

            return admin;
        }

        public bool ChangeAdminPwd(string admin,string newpwd)
        {
            EMSEntities entity = new EMSEntities();
            MEnterpriseAdmin _admin = entity.MEnterpriseAdmin.SingleOrDefault(m => m.AdminName == admin);
            if (_admin == null) return false;
            _admin.MEnterpriseAdminPassword = newpwd;
            entity.SaveChanges();
            return true;
        }
    }
}