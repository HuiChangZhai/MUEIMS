using EnterpriseSystemASPX.DAL;
using EnterpriseSystemASPX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseSystemASPX.BLL
{
    public class BLLTemplate
    {
        public static Templates GetTemplate(int TemplateID)
        {
            DALTemplate _template = new DALTemplate();

            Templates template = _template.GetTemplate(TemplateID);

            return template;
        }
    }
}