using LDCWS.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDCWS.ViewModels
{
    public class MasterDataViewModel
    {

       public int userId { get; set; }
        

        #region outOfUseCode
        //public string ISLAND { get; set; }
        //public string GridBlock { get; set; }
        //public string TRAFO { get; set; }
        //public int FeederID { get; set; }
        //public int Switch_Number { get; set; }
        //public string Switch_Name { get; set; }
        //public string Switch_Type { get; set; }
        //public string FEEDER_TYPE { get; set; }
        //public string Switch_Make { get; set; }
        //public string Group { get; set; }
        //public string Category { get; set; }
        //public string Region { get; set; }
        //public string Cable_Status { get; set; }
        //public string UFR_SW { get; set; }

        //public string Stage_A { get; set; }

        //public string Stage_B { get; set; }

        //public string S1 { get; set; }

        //public string S2 { get; set; }

        //public string S3 { get; set; }

        //public string S4 { get; set; }

        //public string S5 { get; set; }

        //public string S6 { get; set; }

        //public string S7 { get; set; }

        //public string S8 { get; set; }

        //public string S9 { get; set; }

        //public string S10 { get; set; }

        //public string S11 { get; set; }

        //public decimal CAP_OK_MVAR { get; set; }


        //public decimal CAP_MVAR { get; set; }

        //public DateTime dataAddedDateTime { get; set; }

        //public int dataAddedBy { get; set; }
        #endregion

        public List<MasterData> masterData { get; set; }
        
        public int MasterDataSNO { get; set; }
    }
}
