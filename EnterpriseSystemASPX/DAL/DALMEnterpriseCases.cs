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

        public List<MEnterpriseCases> GetBgMEnterpriseCases()
        {
            EMSEntities entity = new EMSEntities();
            List<MEnterpriseCases> _list = entity.MEnterpriseCases.ToList();

            return _list;
        }

        public void DeleteMEnterpriseCases(int cid)
        {
            EMSEntities entity = new EMSEntities();
            MEnterpriseCases cases = entity.MEnterpriseCases.SingleOrDefault(m => m.MEnterpriseCasesID == cid);
            entity.MEnterpriseCases.Remove(cases);
            entity.SaveChanges();
        }

        public void InsertMEnterpriseCases(MEnterpriseCases cases)
        {
            EMSEntities entity = new EMSEntities();
            if (!entity.MEnterpriseCases.Any(m => m.MEnterpriseCasesID == cases.MEnterpriseCasesID))
            {
                entity.MEnterpriseCases.Add(cases);
                entity.SaveChanges();
            }
        }
    }
}