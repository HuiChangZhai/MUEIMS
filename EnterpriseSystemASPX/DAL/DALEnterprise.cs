﻿using System;
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
            Enterprise enterprise = entity.Enterprise.SingleOrDefault(m => m.EnterpriseID == enterpriseid);

            return enterprise;
        }

        public Enterprise GetEnterprise(string enterpriseemail)
        {
            EMSEntities entity = new EMSEntities();
            Enterprise enterprise = entity.Enterprise.SingleOrDefault(m => m.EnterpriseEmail == enterpriseemail);

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
            Enterprise enterprise = entity.Enterprise.SingleOrDefault(m => m.EnterpriseEmail == enterpriseemail);

            return enterprise;
        }
    }
}