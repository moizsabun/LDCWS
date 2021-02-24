using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LDCWS.BO
{
    public class gsmMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int gsmSNO { get; set; }
        public string gsmName { get; set; }
        public string gsmGrid { get; set; }
        public string gsmAddedby { get; set; }
        public DateTime gsmAddedDateTime { get; set; }
    }
}
