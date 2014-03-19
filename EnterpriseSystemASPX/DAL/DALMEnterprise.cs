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

        public void SetMEnterpriseBiref(int id,string brief)
        {
            EMSEntities entity = new EMSEntities();
            if (id <= 0)
            {
                MEnterprise Menterprisenew = new MEnterprise();
                Menterprisenew.MEnterpriseBrief = brief;
                entity.MEnterprise.Add(Menterprisenew);
            }
            else
            {
                MEnterprise Menterprisenew = entity.MEnterprise.SingleOrDefault(m => m.MEnterpriseID == id);
                Menterprisenew.MEnterpriseBrief = brief;
            }
            entity.SaveChanges();
        }

        public void UpdateMEnterprise(MEnterprise _enterprise)
        {
            EMSEntities entity = new EMSEntities();
            if (_enterprise.MEnterpriseID == 0)
                entity.MEnterprise.Add(_enterprise);
            else
            {
                MEnterprise ishave = entity.MEnterprise.Where(m => m.MEnterpriseID == _enterprise.MEnterpriseID).First();
                if (ishave != null)
                {
                    //string brief = ishave.MEnterpriseBrief;
                    ishave.MEnterpriseAddress = _enterprise.MEnterpriseAddress;
                    ishave.MEnterpriseName = _enterprise.MEnterpriseName;
                    ishave.MEnterpriseRight = _enterprise.MEnterpriseRight;
                    ishave.MEnterpriseTelphoneNumber = _enterprise.MEnterpriseTelphoneNumber;
                    ishave.MEnterpriseLogo = _enterprise.MEnterpriseLogo;
                    ishave.MEnterpriseEmail = _enterprise.MEnterpriseEmail;
                    ishave.MEnterpriseBriefShort = _enterprise.MEnterpriseBriefShort;
                    //ishave.MEnterpriseBrief = brief;
                }
            }
            entity.SaveChanges();
        }


    }
}