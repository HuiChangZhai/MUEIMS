using EnterpriseSystemASPX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseSystemASPX.DAL
{
    [Serializable]
    public class DALEnterpriseDynamic
    {
        public List<Models.EnterpriseDynamic> EnterpriseDynamics(int EnterpriseID)
        {
            EMSEntities entity = new EMSEntities();
            List<EnterpriseDynamic> list = entity.EnterpriseDynamic.Where(m => m.EnterpriseID == EnterpriseID).ToList();

            return list;
        }

        public EnterpriseDynamic EnterpriseDynamicByEnterpriseDynamicID(int DynamicID)
        {
            EMSEntities entity = new EMSEntities();
            EnterpriseDynamic enterpriseDynamic = entity.EnterpriseDynamic.SingleOrDefault(m => m.EnterpriseDynamicID == DynamicID);

            return enterpriseDynamic;
        }

        public List<EnterpriseDynamic> GetDALEnterpriseDynamicList(int enterpriseID, int CurrentPage, int PageSize)
        {
            EMSEntities entity = new EMSEntities();
            List<EnterpriseDynamic> list;
            if (enterpriseID != 0)
            {
                list = entity.EnterpriseDynamic.Where(m => m.EnterpriseID == enterpriseID).ToList();
                if (list != null)
                {
                    list = list.OrderBy(m => m.EnterpriseDynamicID).Skip(CurrentPage * PageSize).Take(PageSize).ToList();
                }
            }
            else 
            {
                list = entity.EnterpriseDynamic.OrderByDescending(m => m.EnterpriseDynamicID).Skip(CurrentPage * PageSize).Take(PageSize).ToList();
            }
            

            return list;
        }

        public bool AddEnterpriseDynamic(int enterpriseID, string enterpriseDynamicTitle, string enterpriseDynamicContent)
        {
            EMSEntities entity = new EMSEntities();
            entity.EnterpriseDynamic.Add(new EnterpriseDynamic
            {
                EnterpriseID = enterpriseID,
                EnterpriseDynamicTitle = enterpriseDynamicTitle,
                EnterpriseDynamicContent = enterpriseDynamicContent
            });

            return entity.SaveChanges() != 0;
        }

        internal bool EnterpriseDynamicEdit(int enterpriseDynamicID, string enterpriseDynamicTitle, string enterpriseDynamicContent)
        {
            EMSEntities entity = new EMSEntities();
            EnterpriseDynamic enterpriseDynamic = entity.EnterpriseDynamic.SingleOrDefault(m => m.EnterpriseDynamicID == enterpriseDynamicID);

            if (enterpriseDynamic != null)
            {
                enterpriseDynamic.EnterpriseDynamicTitle = enterpriseDynamicTitle;
                enterpriseDynamic.EnterpriseDynamicContent = enterpriseDynamicContent;
            }

            return entity.SaveChanges() != 0;
        }

        internal bool EnterpriseDynamicDelete(int EnterpriseDynamicID)
        {
            EMSEntities entity = new EMSEntities();
            EnterpriseDynamic enterpriseDynamic = entity.EnterpriseDynamic.SingleOrDefault(m => m.EnterpriseDynamicID == EnterpriseDynamicID);

            if (null != enterpriseDynamic)
            {
                entity.EnterpriseDynamic.Remove(enterpriseDynamic);

                return entity.SaveChanges() != 0;
            }

            return false;
        }
    }
}