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

        public Enterprise GetEnterpriseByEmailOnly(string enterpriseemail)
        {
            EMSEntities entity = new EMSEntities();
            Enterprise enterprise = entity.Enterprise.SingleOrDefault(m => m.EnterpriseEmail == enterpriseemail);

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
        
        public bool RegisterEnterprise(string enterpriseName, string enterpriseEmail , string password, string enterpriseAddress, string enterpriseTel)
        {
            EMSEntities entity = new EMSEntities();
            Enterprise enterprise = new Enterprise
            {
                EnterpriseName = enterpriseName,
                EnterpriseEmail = enterpriseEmail,
                EnterprisePassword = password,
                EnterpriseAddress = enterpriseAddress,
                EnterpriseTelphoneNumber = enterpriseTel,
                EnterpriseRegistTime = DateTime.Now,
                EnterpriseActive = false,
                EnterpriseStatus = false
            };
            entity.Enterprise.Add(enterprise);
            return entity.SaveChanges() != 0;
        }
        public bool ChangePassword(int EnterpriseID, string password)
        {
            EMSEntities entity = new EMSEntities();
            Enterprise enterprise = entity.Enterprise.SingleOrDefault(m => m.EnterpriseID == EnterpriseID);
            if (null != enterprise)
            {
                enterprise.EnterprisePassword = password;
                return entity.SaveChanges() != 0;
            }

            return false;
        }
    }
}