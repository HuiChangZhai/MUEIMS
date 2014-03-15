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

        public MEnterpriseMessage GetMEnterriseMessage(int id)
        {
            EMSEntities entity = new EMSEntities();
            MEnterpriseMessage item = entity.MEnterpriseMessage.SingleOrDefault(m => m.MessageID == id);

            return item;
        }

        public void UpdateMEnterriseMessage(int id,bool read)
        {
            EMSEntities entity = new EMSEntities();
            MEnterpriseMessage item = entity.MEnterpriseMessage.SingleOrDefault(m => m.MessageID == id);
            item.MessageIsRead = read;
            entity.SaveChanges();
        }

        public void DeleteMEnterriseMessage(int id)
        {
            EMSEntities entity = new EMSEntities();
            MEnterpriseMessage item = entity.MEnterpriseMessage.SingleOrDefault(m => m.MessageID == id);
            entity.MEnterpriseMessage.Remove(item);
            entity.SaveChanges();
        }
    }
}