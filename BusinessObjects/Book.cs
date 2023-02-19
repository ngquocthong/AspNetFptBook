using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string book_name { get; set; }
        public string book_author { get; set; }
        public double book_price { get; set; }
        public int quantity { get; set; }
        public int cate_id { get; set; }
        [ForeignKey("cate_id")]
        public virtual Category Category { get; set; }

        public int owner_id { get; set; }
        [ForeignKey("owner_id")]
        public virtual StoreOwner StoreOwner { get; set; }
    }
}
