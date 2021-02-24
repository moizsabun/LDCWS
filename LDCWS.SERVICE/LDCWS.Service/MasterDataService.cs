using LDCWS.BO;
using LDCWS.DA;

using LDCWS.Service.Interfaces;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LDCWS.Service
{
    public class MasterDataService : BaseClass, IMasterData
    {
        public MasterDataService(AppDBContext appDBContext) : base(appDBContext)
        {

        }

        public string AddMasterData(List<MasterData> masterData, int userId)
        {


            //take backup of exsisting Table and then save new Data to DB
            try
            {
                masterData.ForEach(action => { action.dataAddedBy = userId; action.dataAddedDateTime = DateTime.Now; });
                List<MasterData> ExsistingMasterData = _appDBContext.MasterData.ToList();
                List<MasterDataArchive> Archivemasterdata = new List<MasterDataArchive>();


                if (ExsistingMasterData.Count > 0)
                {

                    Archivemasterdata = (from MasterDataArchive in _appDBContext.MasterData.ToList() select MasterDataArchive).Select(x => new MasterDataArchive()
                    {
                        
                        Cable_Status = x.Cable_Status,
                        CAP_MVAR = x.CAP_MVAR,
                        CAP_OK_MVAR = x.CAP_OK_MVAR,
                        Category = x.Category,
                        dataAddedBy = x.dataAddedBy,
                        dataAddedDateTime = x.dataAddedDateTime,
                        FeederID = x.FeederID,
                        FEEDER_TYPE = x.FEEDER_TYPE,
                        GridBlock = x.GridBlock,
                        Group = x.Group,
                        ISLAND = x.ISLAND,
                        ArchiveAddedDateTime = DateTime.Now,
                        ArchiveAddedBy = userId,
                        MasterDataSNO = x.MasterDataSNO,
                        Region = x.Region,
                        S1 = x.S1,
                        S2 = x.S2,
                        S3 = x.S3,
                        S4 = x.S4,
                        S5 = x.S5,
                        S6 = x.S6,
                        S7 = x.S7,
                        S8 = x.S8,
                        S9 = x.S9,
                        S10 = x.S10,
                        S11 = x.S11,
                        Stage_A = x.Stage_A,
                        Stage_B = x.Stage_B,
                        Switch_Make = x.Switch_Make,
                        Switch_Name = x.Switch_Name,
                        Switch_Number = x.Switch_Number,
                        Switch_Type = x.Switch_Type,
                        TRAFO = x.TRAFO,
                        UFR_SW = x.UFR_SW
                    }).ToList();

                    _appDBContext.ArchiveMasterData.AddRange(Archivemasterdata);
                    _appDBContext.SaveChanges();
                    _appDBContext.MasterData.RemoveRange(_appDBContext.MasterData.ToList());
                    _appDBContext.SaveChanges();

                }
                _appDBContext.MasterData.AddRange(masterData);
                if (_appDBContext.SaveChanges() > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Fail";
                }
            }
            catch (Exception ex)
            {

                return "Error Occured! Please check with Business Partner";
            }


        }

        public List<MasterDataCompleteList> GetMasterDataArchieveforDisplay()
        {

            var MasterDataArchive = _appDBContext.ArchiveMasterData;
            var users = _appDBContext.Users;

            var getData = (from mD in MasterDataArchive
                           join usrs in _appDBContext.Users on mD.dataAddedBy equals usrs.userID into Temp
                           from MasData1 in Temp.DefaultIfEmpty()
                           join usr2 in _appDBContext.Users on mD.ArchiveAddedBy equals usr2.userID into Temp2
                           from MasData2 in Temp2.DefaultIfEmpty()

                           select new MasterDataCompleteList
                           {
                               ArchiveAddedDateTime = mD.ArchiveAddedDateTime,
                               ArchiveAddedBy = mD.ArchiveAddedBy,
                               Cable_Status = mD.Cable_Status,
                               CAP_MVAR = mD.CAP_MVAR,
                               CAP_OK_MVAR = mD.CAP_OK_MVAR,
                               Category = mD.Category,
                               dataAddedBy = mD.dataAddedBy,
                               dataAddedDateTime = mD.dataAddedDateTime,
                               FeederID = mD.FeederID,
                               FEEDER_TYPE = mD.FEEDER_TYPE,
                               GridBlock = mD.GridBlock,
                               Group = mD.Group,
                               ISLAND = mD.ISLAND,
                               MasterDataArchiveSNO = mD.MasterDataArchiveSNO,
                               MasterDataSNO = mD.MasterDataSNO,
                               Region = mD.Region,
                               S1 = mD.S1,
                               S2 = mD.S2,
                               S3 = mD.S3,
                               S4 = mD.S4,
                               S5 = mD.S5,
                               S6 = mD.S6,
                               S7 = mD.S7,
                               S8 = mD.S8,
                               S9 = mD.S9,
                               S10 = mD.S10,
                               S11 = mD.S11,
                               Stage_A = mD.Stage_A,
                               Stage_B = mD.Stage_B,
                               Switch_Make = mD.Switch_Make,
                               Switch_Name = mD.Switch_Name,
                               Switch_Number = mD.Switch_Number,
                               Switch_Type = mD.Switch_Type,
                               TRAFO = mD.TRAFO,
                               UFR_SW = mD.UFR_SW,
                               dataAddedName = MasData1.userName,
                               ArchivedataAddedName = MasData2.userName
                           }
             );


            return getData.ToList();
        }

        public string InsertMasterData(List<MasterData> masterData, int userId)
        {
            masterData.ForEach(action => { action.dataAddedBy = userId; action.dataAddedDateTime = DateTime.Now; });
            if (masterData[0].MasterDataSNO != 0)
            {
                masterData[0].MasterDataSNO = 0;
            }
            _appDBContext.MasterData.AddRange(masterData);
            if (_appDBContext.SaveChanges() > 0)
            {
                return "success";
            }
            else
            {
                return "failed";
            }
        }

        public bool updateMasterData(MasterData masterdata, int userId, int MasterDataSNO)
        {

            List<MasterData> ExsistingMasterData = _appDBContext.MasterData.Where(search => search.MasterDataSNO == MasterDataSNO).ToList();
            List<MasterDataArchive> Archivemasterdata = new List<MasterDataArchive>();
            if (ExsistingMasterData.Count > 0)
            {

                Archivemasterdata = (from MasterDataArchive in ExsistingMasterData select MasterDataArchive).Select(x => new MasterDataArchive()
                {
                    Cable_Status = x.Cable_Status,
                    CAP_MVAR = x.CAP_MVAR,
                    CAP_OK_MVAR = x.CAP_OK_MVAR,
                    Category = x.Category,
                    dataAddedBy = x.dataAddedBy,
                    dataAddedDateTime = x.dataAddedDateTime,
                    FeederID = x.FeederID,
                    FEEDER_TYPE = x.FEEDER_TYPE,
                    GridBlock = x.GridBlock,
                    Group = x.Group,
                    ISLAND = x.ISLAND,
                    ArchiveAddedDateTime = DateTime.Now,
                    ArchiveAddedBy = userId,
                    MasterDataSNO = x.MasterDataSNO,
                    Region = x.Region,
                    S1 = x.S1,
                    S2 = x.S2,
                    S3 = x.S3,
                    S4 = x.S4,
                    S5 = x.S5,
                    S6 = x.S6,
                    S7 = x.S7,
                    S8 = x.S8,
                    S9 = x.S9,
                    S10 = x.S10,
                    S11 = x.S11,
                    Stage_A = x.Stage_A,
                    Stage_B = x.Stage_B,
                    Switch_Make = x.Switch_Make,
                    Switch_Name = x.Switch_Name,
                    Switch_Number = x.Switch_Number,
                    Switch_Type = x.Switch_Type,
                    TRAFO = x.TRAFO,
                    UFR_SW = x.UFR_SW
                }).ToList();

                _appDBContext.ArchiveMasterData.AddRange(Archivemasterdata);
                _appDBContext.SaveChanges();
            }
            var exsistingLSData = _appDBContext.MasterData.Where(x => x.MasterDataSNO == masterdata.MasterDataSNO).FirstOrDefault();
            
                    exsistingLSData.dataAddedDateTime = DateTime.Now;
                    exsistingLSData.dataAddedBy = userId;
                    exsistingLSData.Cable_Status = masterdata.Cable_Status;
                    exsistingLSData.CAP_MVAR = masterdata.CAP_MVAR;
                    exsistingLSData.CAP_OK_MVAR = masterdata.CAP_OK_MVAR;
                    exsistingLSData.Category = masterdata.Category;
                    exsistingLSData.FeederID = masterdata.FeederID;
                    exsistingLSData.FEEDER_TYPE = masterdata.FEEDER_TYPE;
                    exsistingLSData.GridBlock = masterdata.GridBlock;
                    exsistingLSData.Group = masterdata.Group;
                    exsistingLSData.ISLAND = masterdata.ISLAND;
                    exsistingLSData.Region = masterdata.Region;
                    exsistingLSData.S1 = masterdata.S1;
                    exsistingLSData.S2 = masterdata.S2;
                    exsistingLSData.S3 = masterdata.S3;
                    exsistingLSData.S4 = masterdata.S4;
                    exsistingLSData.S5 = masterdata.S5;
                    exsistingLSData.S6 = masterdata.S6;
                    exsistingLSData.S7 = masterdata.S7;
                    exsistingLSData.S8 = masterdata.S8;
                    exsistingLSData.S9 = masterdata.S9;
                    exsistingLSData.S10 = masterdata.S10;
                    exsistingLSData.S11 = masterdata.S11;
                    exsistingLSData.Stage_A = masterdata.Stage_A;
                    exsistingLSData.Stage_B = masterdata.Stage_B;
                    exsistingLSData.Switch_Make = masterdata.Switch_Make;
                    exsistingLSData.Switch_Name = masterdata.Switch_Name;
                    exsistingLSData.Switch_Number = masterdata.Switch_Number;
                    exsistingLSData.Switch_Type = masterdata.Switch_Type;
                    exsistingLSData.TRAFO = masterdata.TRAFO;
                    exsistingLSData.UFR_SW = masterdata.UFR_SW;
           
            _appDBContext.MasterData.Update(exsistingLSData);
            if (_appDBContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public List<MasterData> GetMasterDataforDisplay()
        {
            List<MasterData> ExsistingMasterData = _appDBContext.MasterData.ToList();
            return ExsistingMasterData;
        }


        public List<gridBlock> getGridBlock()
        {
            var getData = (from mD in _appDBContext.MasterData


                           select new gridBlock
                           {
                              
                               data = mD.GridBlock

                           }
                           ).Distinct();
            return getData.ToList();

        }


        public List<getGroup> getGroup(string gridBlock)
        {
            var getData = (from mD in _appDBContext.MasterData.Where(x => x.GridBlock == gridBlock && x.Group != null)


                           select new getGroup
                           {

                               data = mD.Group

                           }
                           ).Distinct();
            return getData.ToList();

        }

        public List<getCategory> getCategory(string gridBlock, string Group)
        {
            var getData = (from mD in _appDBContext.MasterData.Where(x => x.GridBlock == gridBlock && x.Group == Group)
                           group mD by mD.Category into temp
                           select new getCategory
                           {
                               categoryCount = temp.Count(),
                               categoryName = temp.Key,
                              

                           }
                           ); 
            return getData.ToList();
        }

        public string DeleteMasterData(MasterData masterData, int userId)
        {
            try
            {
                var exsistingData = _appDBContext.MasterData.Where(x => x.MasterDataSNO == masterData.MasterDataSNO).ToList();
                List<MasterDataArchive> Archivemasterdata = new List<MasterDataArchive>();
                if (exsistingData.Count > 0)
                {

                    Archivemasterdata = (from MasterDataArchive in exsistingData select MasterDataArchive).Select(x => new MasterDataArchive()
                    {
                        Cable_Status = x.Cable_Status,
                        CAP_MVAR = x.CAP_MVAR,
                        CAP_OK_MVAR = x.CAP_OK_MVAR,
                        Category = x.Category,
                        dataAddedBy = x.dataAddedBy,
                        dataAddedDateTime = x.dataAddedDateTime,
                        FeederID = x.FeederID,
                        FEEDER_TYPE = x.FEEDER_TYPE,
                        GridBlock = x.GridBlock,
                        Group = x.Group,
                        ISLAND = x.ISLAND,
                        ArchiveAddedDateTime = DateTime.Now,
                        ArchiveAddedBy = userId,
                        MasterDataSNO = x.MasterDataSNO,
                        Region = x.Region,
                        S1 = x.S1,
                        S2 = x.S2,
                        S3 = x.S3,
                        S4 = x.S4,
                        S5 = x.S5,
                        S6 = x.S6,
                        S7 = x.S7,
                        S8 = x.S8,
                        S9 = x.S9,
                        S10 = x.S10,
                        S11 = x.S11,
                        Stage_A = x.Stage_A,
                        Stage_B = x.Stage_B,
                        Switch_Make = x.Switch_Make,
                        Switch_Name = x.Switch_Name,
                        Switch_Number = x.Switch_Number,
                        Switch_Type = x.Switch_Type,
                        TRAFO = x.TRAFO,
                        UFR_SW = x.UFR_SW
                    }).ToList();

                    _appDBContext.ArchiveMasterData.AddRange(Archivemasterdata);
                    _appDBContext.SaveChanges();
                }
               
                _appDBContext.MasterData.RemoveRange(exsistingData);
                _appDBContext.SaveChanges();
                return "Success";
            }
            catch (Exception)
            {

                throw;
            }
           
            
    }
    }

   
}
