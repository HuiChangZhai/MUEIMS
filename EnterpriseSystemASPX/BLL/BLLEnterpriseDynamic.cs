using EnterpriseSystemASPX.DAL;
using EnterpriseSystemASPX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseSystemASPX.BLL
{
    [Serializable]
    public static class BLLEnterpriseDynamic
    {
        public static List<EnterpriseDynamic> EnterpriseDynamics(int EnterpriseID)
        {
            DALEnterpriseDynamic _DAL = new DALEnterpriseDynamic();
            List<EnterpriseDynamic> list = _DAL.EnterpriseDynamics(EnterpriseID);

            return list;
        }

        public static EnterpriseDynamic EnterpriseDynamicByEnterpriseDynamicID(int EnterpriseID)
        {
            DALEnterpriseDynamic _DAL = new DALEnterpriseDynamic();

            return _DAL.EnterpriseDynamicByEnterpriseDynamicID(EnterpriseID);
        }

        public static List<EnterpriseDynamic> EnterpriseDynamic(int CurrentPage, int PageSize)
        {
            DALEnterpriseDynamic _DAL = new DALEnterpriseDynamic();
            List<EnterpriseDynamic> list = _DAL.GetDALEnterpriseDynamicList(CurrentPage, PageSize);

            return list;
        }

        public static bool AddEnterpriseDynamic(int enterpriseID, string enterpriseDynamicTitle, string enterpriseDynamicContent)
        {
            DALEnterpriseDynamic _DAL = new DALEnterpriseDynamic();
            return _DAL.AddEnterpriseDynamic(enterpriseID, enterpriseDynamicTitle, enterpriseDynamicContent);
        }

        public static bool EnterpriseDynamicEdit(int enterpriseDynamicID, string enterpriseDynamicTitle, string enterpriseDynamicContent)
        {
            DALEnterpriseDynamic _DAL = new DALEnterpriseDynamic();
            return _DAL.EnterpriseDynamicEdit(enterpriseDynamicID, enterpriseDynamicTitle, enterpriseDynamicContent);
        }

        internal static bool EnterpriseDynamicDelete(int EnterpriseDynamicID)
        {
            DALEnterpriseDynamic _DAL = new DALEnterpriseDynamic();
            return _DAL.EnterpriseDynamicDelete(EnterpriseDynamicID);
        }
    }
}