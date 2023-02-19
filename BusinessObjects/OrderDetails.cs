using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class OrderDetails
    {

        [Key]
        public int order_id { get; set; }
        [Key]
        public int book_id { get; set; }

        [ForeignKey("order_id")]
        public virtual Order? Order { get; set; }
        [ForeignKey("book_id")]
        public virtual Book? Book { get; set; }

    }
}
