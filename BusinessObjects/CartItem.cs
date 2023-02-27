

using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class CartItem
    {
        public int quantity { get; set; }
        public Book? book { get; set; }
		public string cus_id { get; set; }
	}
}
