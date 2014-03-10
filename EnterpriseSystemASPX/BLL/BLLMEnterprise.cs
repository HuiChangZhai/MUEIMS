using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnterpriseSystemASPX.DAL;
using EnterpriseSystemASPX.Models;

namespace EnterpriseSystemASPX.BLL
{
    [Serializable]
    public static class BLLMEnterprise
    {
        public static MEnterprise GetMEnterprise()
        {
            DALMEnterprise _DAL = new DALMEnterprise();

            MEnterprise _Menterprise = _DAL.GetMEnterprise();
            return _Menterprise;
        }
    }
}