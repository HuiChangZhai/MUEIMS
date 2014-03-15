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

        public bool SaveEnterpriseInfoChanges(int enterpriseID,string enterpriseName,string enterpriseUrl,string enterpriseAddress,string enterpriseTelphoneNumber,string enterpriseEmail,string enterpriseRight,string EnterpriseLogo)
        {
            EMSEntities entity = new EMSEntities();
            Enterprise enterprise = entity.Enterprise.SingleOrDefault(m => m.EnterpriseID == enterpriseID);
            if (enterprise != null)
            {
                if (enterpriseName != null) 
                    enterprise.EnterpriseName = enterpriseName;

                if (enterpriseUrl != null) 
                    enterprise.EnterpriseUrl = enterpriseUrl;

                if (enterpriseAddress != null) 
                    enterprise.EnterpriseAddress = enterpriseAddress;

                if (enterpriseTelphoneNumber != null) 
                    enterprise.EnterpriseTelphoneNumber = enterpriseTelphoneNumber;

                if (enterpriseEmail != null) 
                    enterprise.EnterpriseEmail = enterpriseEmail;

                if (enterpriseRight != null) 
                    enterprise.EnterpriseRight = enterpriseRight;

                if (EnterpriseLogo != null)
                    enterprise.EnterpriseLogo = EnterpriseLogo;

                return entity.SaveChanges() != 0;
            }
            return false;
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
    }
}