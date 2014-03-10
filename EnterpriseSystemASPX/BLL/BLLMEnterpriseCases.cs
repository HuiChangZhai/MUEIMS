using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}