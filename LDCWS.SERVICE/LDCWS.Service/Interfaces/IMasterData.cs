
using LDCWS.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDCWS.Service.Interfaces
{
   public interface IMasterData
    {
        public string AddMasterData(List<MasterData> masterData,int userId);
        public bool updateMasterData(MasterData masterdata,int userId,int MasterDataSNO);
        public List<MasterDataCompleteList> GetMasterDataArchieveforDisplay();
        public List<MasterData> GetMasterDataforDisplay();
        public string InsertMasterData(List<MasterData> masterData, int userId);
        public string DeleteMasterData(MasterData masterData, int userId);
        public List<gridBlock> getGridBlock();
        List<getGroup> getGroup(string gridBlock);
        List<getCategory> getCategory(string gridBlock, string Group);
    }
}
