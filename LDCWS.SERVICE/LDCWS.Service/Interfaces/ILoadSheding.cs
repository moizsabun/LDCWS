using LDCWS.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDCWS.Service.Interfaces
{
   public interface ILoadSheding
    {
        public string addLoadsheddindgData(LoadShedding ls, int userId);
        public string EditLoadsheddindgData(LoadShedding ls, int userId);
        public string editExpiry(DateTime expiry, int userId);

        public List<LoadShedding> getAllLoadSheddingData();

        public List<LoadSheddingCompleteList> GetLSDataArchieveforDisplay();


    }
}
