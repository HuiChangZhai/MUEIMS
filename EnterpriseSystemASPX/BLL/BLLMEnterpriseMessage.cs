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
    }
}