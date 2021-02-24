using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LDCWS.BO
{
   public class emailMapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int emailMappingSNO { get; set; }
        public string to { get; set; }
        public string cc { get; set; }
        public int gsmID { get; set; }
        public string emailMappingAddedby { get; set; }
        public DateTime emailMappingDateTime { get; set; }
    }
}
