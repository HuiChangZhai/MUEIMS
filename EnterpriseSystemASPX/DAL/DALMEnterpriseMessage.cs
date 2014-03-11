using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnterpriseSystemASPX.Models;

namespace EnterpriseSystemASPX.DAL
{
    public class DALMEnterpriseMessage
    {
        public void SetMEnterriseMessage(MEnterpriseMessage message)
        {
            EMSEntities entity = new EMSEntities();
            entity.MEnterpriseMessage.Add(message);

            entity.SaveChanges();
        }

        public List<MEnterpriseMessage> GetMEnterriseMessage()
        {
            EMSEntities entity = new EMSEntities();
            List<MEnterpriseMessage> list = entity.MEnterpriseMessage.ToList();

            return list;
        }
    }
}