using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public double cart_totalPrice { get; set; }
        public int cart_quantity { get; set; }
        public int cus_id { get; set; }
        [ForeignKey("cus_id")]
        public virtual Customer Customer { get; set; }
    }
}
