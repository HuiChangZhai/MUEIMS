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
        public List<Enterprise> GetEnterprise()
        {
            EMSEntities entity = new EMSEntities();
            List<Enterprise> list = entity.Enterprise.Where(m=>m.EnterpriseStatus.Value).ToList();

            return list;
        }

        public Enterprise GetEnterprise(int enterpriseid)
        {
            EMSEntities entity = new EMSEntities();
            Enterprise enterprise = entity.Enterprise.SingleOrDefault(m => m.EnterpriseID == enterpriseid && m.EnterpriseStatus.Value);

            return enterprise;
        }

        public Enterprise GetBgEnterprise(int id)
        {
            EMSEntities entity = new EMSEntities();
            Enterprise enterprise = entity.Enterprise.SingleOrDefault(m => m.EnterpriseID == id);

            return enterprise;
        }

        public Enterprise GetEnterprise(string enterpriseemail)
        {
            EMSEntities entity = new EMSEntities();
            Enterprise enterprise = entity.Enterprise.SingleOrDefault(m => m.EnterpriseEmail == enterpriseemail && m.EnterpriseStatus.Value);

            return enterprise;
        }

        public Enterprise GetEnterprise(string enterpriseemail,string enterprisepwd)
        {
            EMSEntities entity = new EMSEntities();
            Enterprise enterprise = entity.Enterprise.SingleOrDefault(m => m.EnterpriseEmail == enterpriseemail && m.EnterprisePassword == enterprisepwd);

            return enterprise;
        }

        public Enterprise ExistEnterprise(string enterpriseemail)
        {
            EMSEntities entity = new EMSEntities();
            Enterprise enterprise = entity.Enterprise.SingleOrDefault(m => m.EnterpriseEmail == enterpriseemail && m.EnterpriseStatus.Value);

            return enterprise;
        }

        public List<Enterprise> GetEnterpriseList(int page, int pageSize)
        {
            EMSEntities entity = new EMSEntities();
            List<Enterprise> enterpriseList = entity.Enterprise.OrderBy(m=>m.EnterpriseID).Skip(page * pageSize).Take(pageSize).ToList();

            return enterpriseList;
        }

        public static int SaveChanges()
        {
            EMSEntities entity = new EMSEntities();
            return entity.SaveChanges();
        }

        public bool SetEnterpriseBrief(int enterpriseID, string brief) 
        {
            EMSEntities entity = new EMSEntities();
            Enterprise enterprise = entity.Enterprise.SingleOrDefault(m=> m.EnterpriseID==enterpriseID);
            if(enterprise != null)
            {
                enterprise.EnterpriseBrief = brief;
                return entity.SaveChanges() != 0;
            }
            return false;
        }

        public void DeleteEnterprise(int id)
        {
            EMSEntities entity = new EMSEntities();
            Enterprise item = entity.Enterprise.SingleOrDefault(m => m.EnterpriseID == id);
            entity.Enterprise.Remove(item);
            entity.SaveChanges();
        }

        public bool SetEnterpriseStatus(int id, bool status)
        {
            EMSEntities entity = new EMSEntities();
            Enterprise enterprise = entity.Enterprise.SingleOrDefault(m => m.EnterpriseID == id);
            if (enterprise != null)
            {
                enterprise.EnterpriseStatus = status;
                return entity.SaveChanges() != 0;
            }
            return false;
        }
    }
}