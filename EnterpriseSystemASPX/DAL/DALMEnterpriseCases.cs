using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnterpriseSystemASPX.Models;

namespace EnterpriseSystemASPX.DAL
{
    [Serializable]
    public class DALMEnterpriseCases
    {
        public List<MEnterpriseCases> GetMEnterpriseCases()
        {
            EMSEntities entity = new EMSEntities();
            List<MEnterpriseCases> _list = entity.MEnterpriseCases.Where(m => m.MEnterpriseCaseShow).ToList();

            return _list;
        }
    }
}