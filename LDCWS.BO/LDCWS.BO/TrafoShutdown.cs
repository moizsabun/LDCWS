using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LDCWS.BO
{
    public class TrafoShutdown
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrafoShutdownSNO { get; set; }
        public string grid { get; set; }
        public string block { get; set; }
        public string time { get; set; }
        public string date { get; set; }
        public string feederAffected { get; set; }
        public string reason { get; set; }
        public int? rating { get; set; }
        public string loadTakenOn { get; set; }
        public string gsm { get; set; }
        public string shutdownAddedby { get; set; }
        public DateTime shutdownAddedDateTime { get; set; }
    }
}
