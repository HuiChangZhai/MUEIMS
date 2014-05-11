using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSystemASPX.DAL;
using EnterpriseSystemASPX.Models;

namespace EnterpriseSystemASPX.BLL
{
    [Serializable]
    public static class BLLMEnterpriseCases
    {
        public static List<MEnterpriseCases> GetMEnterpriseCases()
        {
            DALMEnterpriseCases _DAL = new DALMEnterpriseCases();
            List<MEnterpriseCases> _list = _DAL.GetMEnterpriseCases();

            return _list;
        }

        public static List<MEnterpriseCases> GetMEnterpriseCasesAll()
        {
            DALMEnterpriseCases _DAL = new DALMEnterpriseCases();
            List<MEnterpriseCases> _list = _DAL.GetMEnterpriseCasesAll();

            return _list;
        }

        public static MEnterpriseCases GetMEnterpriseCases(int id)
        {
            DALMEnterpriseCases _DAL = new DALMEnterpriseCases();
            List<MEnterpriseCases> allList = _DAL.GetBgMEnterpriseCases();

            MEnterpriseCases cases = allList.SingleOrDefault(m => m.MEnterpriseCasesID == id);

            return cases;
        }

        public static List<MEnterpriseCases> GetMEnterpriseCases(PageHelper page, int pageindex)
        {
            DALMEnterpriseCases _DAL = new DALMEnterpriseCases();
            List<MEnterpriseCases> allList = _DAL.GetBgMEnterpriseCases();

            List<MEnterpriseCases> pageList = allList.Skip(page.PageSize * (pageindex - 1)).Take(page.PageSize).ToList();

            return pageList;
        }

        public static void DeleteMEnterpriseCases(int cid)
        {
            DALMEnterpriseCases _DAL = new DALMEnterpriseCases();

            _DAL.DeleteMEnterpriseCases(cid);
        }

        public static List<SelectListItem> GetCasesList()
        {
            List<Enterprise> Elist = BLLEnterprise.GetEnterprise();
            List<MEnterpriseCases> Mlist = BLLMEnterpriseCases.GetMEnterpriseCases();
            List<SelectListItem> list = new List<SelectListItem>();
            
            foreach (MEnterpriseCases item in Mlist)
            {
                Elist.RemoveAll(m => m.EnterpriseUrl==item.EnterprisUrl);
            }
            list.Add(new SelectListItem() { Text = "--请选择--", Value = "0" });
            foreach (Enterprise item in Elist)
            {
                list.Add(new SelectListItem() { Text = item.EnterpriseName, Value = item.EnterpriseID.ToString() });
            }

            return list;
        }

        public static void InsertMEnterpriseCases(MEnterpriseCases cases)
        {
            DALMEnterpriseCases _DAL = new DALMEnterpriseCases();

            _DAL.InsertMEnterpriseCases(cases);
        }
    }
}