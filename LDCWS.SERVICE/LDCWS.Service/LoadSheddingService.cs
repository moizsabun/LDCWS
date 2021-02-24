using LDCWS.BO;
using LDCWS.DA;
using LDCWS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LDCWS.Service
{
    public class LoadSheddingService : BaseClass, ILoadSheding
    {

        public LoadSheddingService(AppDBContext appdbContext) : base(appdbContext)
        { }
        public string addLoadsheddindgData(LoadShedding ls, int userId)
        {
            try
            {
                var getLastExpiry = _appDBContext.loadShedding.FirstOrDefault();
                if (getLastExpiry != null)
                {
                    ls.planExpiry = getLastExpiry.planExpiry;
                }
                ls.dataAddedDateTime = DateTime.Now;
                ls.dataAddedBy = userId;
                _appDBContext.loadShedding.Add(ls);
                int result = _appDBContext.SaveChanges();
                if(result > 0)
                {
                    return "success";
                }
                else
                {

                    return "fail";
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string editExpiry(DateTime expiry, int userId)
        {

            List<LoadShedding> ExsistingLS = _appDBContext.loadShedding.ToList();
            List<LoadSheddingArchive> ArchiveheddingArchive = new List<LoadSheddingArchive>();

            ArchiveheddingArchive = (from LoadSheddingArchive in _appDBContext.loadShedding.ToList() select LoadSheddingArchive).Select(x => new LoadSheddingArchive()
            { 
                block = x.block  ,
                group = x.group ,
                hlFeeders = x.hlFeeders,
                mlFeeders = x.mlFeeders,
                vhlFeeders = x.vhlFeeders,
                llFeders = x.llFeders,
                dataAddedBy = x.dataAddedBy,
                dataAddedDateTime = x.dataAddedDateTime,
                planExpiry = x.planExpiry,
                spell_1_to_and_From = x.spell_1_to_and_From,
                spell_2_to_and_From =x.spell_2_to_and_From,
                spell_3_to_and_From =x.spell_3_to_and_From,
                spell_4_to_and_From = x.spell_4_to_and_From,
                spell_5_to_and_From =  x.spell_5_to_and_From,
                spell_6_to_and_From = x.spell_6_to_and_From,
                totalFeeders = x.totalFeeders,
                LoadSheddingSNO = x.LoadSheddingSNO,
                ArchiveAddedBy = userId,
                ArchiveAddedDateTime = DateTime.Now,
             

            
            }).ToList();
            try
            {
                _appDBContext.ArchiveloadShedding.AddRange(ArchiveheddingArchive);
                _appDBContext.SaveChanges();
                ExsistingLS.ForEach(x => { x.planExpiry = expiry; x.dataAddedBy = userId; });
                _appDBContext.loadShedding.UpdateRange(ExsistingLS);
                _appDBContext.SaveChanges();
                return "success";
            }
            catch (Exception)
            {

                throw;
            }
           

           


        }

        public string EditLoadsheddindgData(LoadShedding ls, int userId)
        {
            try
            {

                List<LoadSheddingArchive> ArchiveheddingArchive = new List<LoadSheddingArchive>();

                ArchiveheddingArchive = (from LoadSheddingArchive in _appDBContext.loadShedding.Where(x => x.LoadSheddingSNO == ls.LoadSheddingSNO) select LoadSheddingArchive).Select(x => new LoadSheddingArchive()
                {
                    block = x.block,
                    group = x.group,
                    hlFeeders = x.hlFeeders,
                    mlFeeders = x.mlFeeders,
                    vhlFeeders = x.vhlFeeders,
                    llFeders = x.llFeders,
                    dataAddedBy = x.dataAddedBy,
                    dataAddedDateTime = x.dataAddedDateTime,
                    planExpiry = x.planExpiry,
                    spell_1_to_and_From = x.spell_1_to_and_From,
                    spell_2_to_and_From = x.spell_2_to_and_From,
                    spell_3_to_and_From = x.spell_3_to_and_From,
                    spell_4_to_and_From = x.spell_4_to_and_From,
                    spell_5_to_and_From = x.spell_5_to_and_From,
                    spell_6_to_and_From = x.spell_6_to_and_From,
                    totalFeeders = x.totalFeeders,
                    LoadSheddingSNO = x.LoadSheddingSNO,
                    ArchiveAddedBy = userId,
                    ArchiveAddedDateTime = DateTime.Now,



                }).ToList();
                _appDBContext.ArchiveloadShedding.AddRange(ArchiveheddingArchive);
                var getLSDATA = _appDBContext.loadShedding.Where(x => x.LoadSheddingSNO == ls.LoadSheddingSNO).FirstOrDefault();
                getLSDATA.block = ls.block;
                getLSDATA.dataAddedBy = userId;
                getLSDATA.dataAddedDateTime = DateTime.Now;
                getLSDATA.group = ls.group;
                getLSDATA.hlFeeders = ls.hlFeeders;
                getLSDATA.mlFeeders = ls.mlFeeders;
                getLSDATA.vhlFeeders = ls.vhlFeeders;
                getLSDATA.llFeders = ls.llFeders;
                getLSDATA.dataAddedBy = ls.dataAddedBy;
                getLSDATA.dataAddedDateTime = ls.dataAddedDateTime;
                getLSDATA.planExpiry = ls.planExpiry;
                getLSDATA.spell_1_to_and_From = ls.spell_1_to_and_From;
                getLSDATA.spell_2_to_and_From = ls.spell_2_to_and_From;
                getLSDATA.spell_3_to_and_From = ls.spell_3_to_and_From;
                getLSDATA.spell_4_to_and_From = ls.spell_4_to_and_From;
                getLSDATA.spell_5_to_and_From = ls.spell_5_to_and_From;
                getLSDATA.spell_6_to_and_From = ls.spell_6_to_and_From;
                getLSDATA.totalFeeders = ls.totalFeeders;



                _appDBContext.loadShedding.Update(getLSDATA);
                _appDBContext.SaveChanges();

                return "Sucess";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LoadShedding> getAllLoadSheddingData()
        {
            try
            {
                var getData = _appDBContext.loadShedding.ToList();
                return getData;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<LoadSheddingCompleteList> GetLSDataArchieveforDisplay()
        {

            var LSArchive = _appDBContext.ArchiveloadShedding;
            var users = _appDBContext.Users;

            var getData = (from mD in LSArchive
                           join usrs in _appDBContext.Users on mD.dataAddedBy equals usrs.userID into Temp
                           from LSData1 in Temp.DefaultIfEmpty()
                           join usr2 in _appDBContext.Users on mD.ArchiveAddedBy equals usr2.userID into Temp2
                           from LSData2 in Temp2.DefaultIfEmpty()
                           
                           select new LoadSheddingCompleteList
                           {
                               ArchiveAddedDateTime = mD.ArchiveAddedDateTime,
                               ArchiveAddedBy = mD.ArchiveAddedBy,
                               ArchiveAddedByName = LSData2.userName,
                               ArchiveLoadSheddingSNO = mD.ArchiveLoadSheddingSNO,
                               planExpiry = mD.planExpiry,
                               block = mD.block,
                               dataAddedBy = mD.dataAddedBy,
                               dataAddedByName =LSData1.userName,
                               
                               dataAddedDateTime = mD.dataAddedDateTime,hlFeeders =  mD.hlFeeders ,
                               llFeders = mD.llFeders,
                               LoadSheddingSNO = mD.LoadSheddingSNO,
                               mlFeeders = mD.mlFeeders,
                               spell_1_to_and_From = mD.spell_1_to_and_From,
                               spell_2_to_and_From = mD.spell_2_to_and_From,
                               spell_3_to_and_From = mD.spell_3_to_and_From,
                               spell_4_to_and_From= mD.spell_4_to_and_From,
                               spell_5_to_and_From = mD.spell_5_to_and_From,
                               spell_6_to_and_From = mD.spell_6_to_and_From,
                               totalFeeders = mD.totalFeeders,
                               vhlFeeders = mD.vhlFeeders,
                               @group = mD.@group ,
                              
                              
                             

                               
                           }
             );


            return getData.ToList();
        }
    }
}
