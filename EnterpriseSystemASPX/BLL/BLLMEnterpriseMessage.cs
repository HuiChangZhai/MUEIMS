using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnterpriseSystemASPX.DAL;
using EnterpriseSystemASPX.Models;

namespace EnterpriseSystemASPX.BLL
{
    public static class BLLMEnterpriseMessage
    {
        public static void SetMEnterriseMessage(MEnterpriseMessage message)
        {
            DALMEnterpriseMessage _DAL = new DALMEnterpriseMessage();
            
            _DAL.SetMEnterriseMessage(message);
        }

        public static List<MEnterpriseMessage> GetMEnterriseMessage()
        {
            DALMEnterpriseMessage _DAL = new DALMEnterpriseMessage();

            return _DAL.GetMEnterriseMessage();
        }

        public static List<MEnterpriseMessage> GetPageMessage(PageHelper page,int pageindex)
        {
            List<MEnterpriseMessage> allList = GetMEnterriseMessage();

            List<MEnterpriseMessage> pageList = allList.Skip(page.PageSize*(pageindex-1)).Take(page.PageSize).ToList();

            return pageList;
        }

        public static MEnterpriseMessage GetMEnterriseMessage(int id)
        {
            DALMEnterpriseMessage _DAL = new DALMEnterpriseMessage();

            return _DAL.GetMEnterriseMessage(id);
        }

        public static void UpdateMEnterriseMessage(int id, bool read)
        {
            DALMEnterpriseMessage _DAL = new DALMEnterpriseMessage();

            _DAL.UpdateMEnterriseMessage(id, read);
        }

        public static void DeleteMEnterriseMessage(int id)
        {
            DALMEnterpriseMessage _DAL = new DALMEnterpriseMessage();

            _DAL.DeleteMEnterriseMessage(id);
        }
    }

}