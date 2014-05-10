using EnterpriseSystemASPX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseSystemASPX.DAL
{
    public class DALTemplate
    {
        public Templates GetTemplate(int TemplateID) 
        {
            EMSEntities entity = new EMSEntities();
            Templates template = entity.Templates.SingleOrDefault(m => m.TemplateID == TemplateID);

            return template;
        }

        public List<Templates> GetTemplateList()
        {
            EMSEntities entity = new EMSEntities();
            List<Templates> list = entity.Templates.ToList();

            return list;
        }
    }
}