using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LDCWS.BO
{
   public class EmailBody
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int emailSNO { get; set; }
        public string emailSubject { get; set; }
        public string emailBody { get; set; }
        public string emailAddedby { get; set; }
        public DateTime emailAddedDateTime { get; set; }
    }
}
