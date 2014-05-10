using EnterpriseSystemASPX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseSystemASPX.DAL
{
    [Serializable]
    public class DALEnterpriseCases
    {
        public List<EnterpriseCases> EnterpriseCases(int EnterpriseID)
        {
            EMSEntities entity = new EMSEntities();
            List<EnterpriseCases> list = entity.EnterpriseCases.Where(m => m.EnterpriseID == EnterpriseID).ToList();

            return list;
        }

        public EnterpriseCases EnterpriseCaseByEnterpriseCaseID(int EnterpriseCaseID) 
        {
            EMSEntities entity = new EMSEntities();
            EnterpriseCases enterpriseCases = entity.EnterpriseCases.SingleOrDefault(m => m.EnterpriseCasesID == EnterpriseCaseID);

            return enterpriseCases;
        }

        public List<EnterpriseCases> GetEnterpriseCasesList(int enterpriseID, int CurrentPage, int PageSize)
        {
            EMSEntities entity = new EMSEntities();
            
            List<EnterpriseCases> list;
 
            if (enterpriseID != 0)
            { 
                list = entity.EnterpriseCases.Where(m=>m.EnterpriseID == enterpriseID).ToList();
                if(list!= null)
                {
                    list = list.OrderByDescending(m=>m.EnterpriseCasesID).Skip(CurrentPage * PageSize).Take(PageSize).ToList();
                }
            }
            else
            {
                list = entity.EnterpriseCases.OrderBy(m=>m.EnterpriseCasesID).Skip(CurrentPage * PageSize).Take(PageSize).ToList();
            }

            return list;
        }

        public bool AddEnterpriseCase(int enterpriseID, string enterpriseCaseTitle, string enterpriseCaseContent)
        {
            EMSEntities entity = new EMSEntities();
            entity.EnterpriseCases.Add(new EnterpriseCases
            {
                EnterpriseID = enterpriseID,
                EnterpriseTitle = enterpriseCaseTitle,
                EnterpriseContent = enterpriseCaseContent
            });

            return entity.SaveChanges() != 0;
        }

        internal bool EnterpriseCaseEdit(int enterpriseCaseID, string enterpriseCaseTitle, string enterpriseCaseContent)
        {
            EMSEntities entity = new EMSEntities();
            EnterpriseCases enterpriseCases =  entity.EnterpriseCases.SingleOrDefault(m => m.EnterpriseCasesID == enterpriseCaseID);

            if (enterpriseCases != null)
            {
                enterpriseCases.EnterpriseTitle = enterpriseCaseTitle;
                enterpriseCases.EnterpriseContent = enterpriseCaseContent;
                return entity.SaveChanges() != 0;
            }

            return false;
        }

        internal bool EnterpriseCaseDelete(int EnterpriseCaseID)
        {
            EMSEntities entity = new EMSEntities();
            EnterpriseCases enterpriseCase = entity.EnterpriseCases.SingleOrDefault(m => m.EnterpriseCasesID == EnterpriseCaseID);
            if (null != enterpriseCase)
            {
                entity.EnterpriseCases.Remove(enterpriseCase);

                return entity.SaveChanges() != 0;
            }

            return false;
        }
    }
}