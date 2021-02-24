using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LDCWS.BO
{
    public class LoadShedding
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoadSheddingSNO { get; set; }
        public string group { get; set; }
        public string block { get; set; }
        public int ? llFeders { get; set; }
        public int ? mlFeeders { get; set; }
        public int? hlFeeders { get; set; }
        public int? vhlFeeders { get; set; }
        public int? totalFeeders { get; set; }
        public string spell_1_to_and_From { get; set; }
        public string spell_2_to_and_From { get; set; }
        public string spell_3_to_and_From { get; set; }
        public string spell_4_to_and_From { get; set; }
        public string spell_5_to_and_From { get; set; }
        public string spell_6_to_and_From { get; set; }
   
        public DateTime? planExpiry { get; set; }
        public DateTime? dataAddedDateTime { get; set; }
        public int?  dataAddedBy { get; set; }

    }
}
