using EnterpriseSystemASPX.DAL;
using EnterpriseSystemASPX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseSystemASPX.BLL
{
    [Serializable]
    public static class BLLEnterpriseCases
    {
        public static List<EnterpriseCases> EnterpriseCases(int EnterpriseID)
        {
            DALEnterpriseCases _DAL = new DALEnterpriseCases();
            List<EnterpriseCases> list = _DAL.EnterpriseCases(EnterpriseID);

            return list;
        }

        public static EnterpriseCases EnterpriseCaseByEnterpriseCaseID(int EnterpriseID)
        {
            DALEnterpriseCases _DAL = new DALEnterpriseCases();

            return _DAL.EnterpriseCaseByEnterpriseCaseID(EnterpriseID);
        }

        public static List<EnterpriseCases> GetEnterpriseCasesList(int enterpriseID,int CurrentPage, int PageSize)
        {
            DALEnterpriseCases _DAL = new DALEnterpriseCases();
            List<EnterpriseCases> list = _DAL.GetEnterpriseCasesList(enterpriseID, CurrentPage, PageSize);

            return list;
        }

        public static bool AddEnterpriseCase(int enterpriseID, string enterpriseCaseTitle, string enterpriseCaseContent)
        {
            DALEnterpriseCases _DAL = new DALEnterpriseCases();
            return _DAL.AddEnterpriseCase(enterpriseID, enterpriseCaseTitle, enterpriseCaseContent);
        }

        public static bool EnterpriseCaseEdit(int enterpriseCaseID, string enterpriseCaseTitle, string enterpriseCaseContent)
        {
            DALEnterpriseCases _DAL = new DALEnterpriseCases();
            return _DAL.EnterpriseCaseEdit(enterpriseCaseID, enterpriseCaseTitle, enterpriseCaseContent);
        }

        public static bool EnterpriseCaseDelete(int EnterpriseCaseID)
        {
            DALEnterpriseCases _DAL = new DALEnterpriseCases();
            return _DAL.EnterpriseCaseDelete(EnterpriseCaseID);
        }
    }
}