using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BusinessObjects
{
    public class OrderDetails
    {
        [Key]
		[JsonIgnore]
		public int order_id { get; set; }
        [Key]
        public int book_id { get; set; }
		public int quantity { get; set; }

		[ForeignKey("order_id")]
		[JsonIgnore]
		public virtual Order? Order { get; set; }
        [ForeignKey("book_id")]
		[JsonIgnore]
		public virtual Book? Book { get; set; }
	

	}
}
