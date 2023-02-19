using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int cus_username { get; set; }
        public int cus_pass { get; set; }
        public int cus_name { get; set; }
        public DateTime dob { get; set; }
        public string gender { get; set; }
        public int cus_address { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
