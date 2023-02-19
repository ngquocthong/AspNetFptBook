using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public double totalPrice { get; set; }
        public DateTime createdDate { get; set; }
        public bool status { get; set; }
        public string shippingAddress { get; set; }
        public int cus_id { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
