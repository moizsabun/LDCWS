using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LDCWS.BO
{
    public class MasterDataArchive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MasterDataArchiveSNO { get; set; }
        public int MasterDataSNO { get; set; }
        public string ISLAND { get; set; }
        public string GridBlock { get; set; }
        public string TRAFO { get; set; }
        public int FeederID { get; set; }
        public string Switch_Number { get; set; }
        public string Switch_Name { get; set; }
        public string Switch_Type { get; set; }
        public string FEEDER_TYPE { get; set; }
        public string Switch_Make { get; set; }
        public string Group { get; set; }
        public string Category { get; set; }
        public string Region { get; set; }
        public string Cable_Status { get; set; }
        public string UFR_SW { get; set; }
        [Description("Stage_A 49.4 df/dt")]
        public string Stage_A { get; set; }
        [Description("Stage_B 49.4 df/dt")]
        public string Stage_B { get; set; }
        [Description("49.3(S1)")]
        public string S1 { get; set; }
        [Description("49.2(S2) 50 ms3")]
        public string S2 { get; set; }
        [Description("49.0 (S3) 150ms")]
        public string S3 { get; set; }
        [Description("48.8 (S4) 200ms")]
        public string S4 { get; set; }
        [Description("48.6(S5) 50 ms")]
        public string S5 { get; set; }
        [Description("48.6(S6) 200 ms")]
        public string S6 { get; set; }
        [Description("48.6(S7) 300 ms")]
        public string S7 { get; set; }
        [Description("48.5(S8) 100 ms")]
        public string S8 { get; set; }
        [Description("48.5(S9) 50 ms")]
        public string S9 { get; set; }
        [Description("48.4(S10) 100 ms")]
        public string S10 { get; set; }
        [Description("48.4(S11) 50 ms")]
        public string S11 { get; set; }

        public decimal CAP_OK_MVAR { get; set; }

        [Description("CAP (Faulty, drop) MVAR")]
        public decimal CAP_MVAR { get; set; }

        public DateTime dataAddedDateTime { get; set; }

        public int dataAddedBy { get; set; }
        
        public DateTime ArchiveAddedDateTime { get; set; }

        public int ArchiveAddedBy { get; set; }
    }
}
