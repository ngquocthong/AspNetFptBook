
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObjects
{
	public class Order
	{
		[JsonIgnore]
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		
		public int ID { get; set; }
		public double totalPrice { get; set; }
		public DateTime createdDate { get; set; }
		public bool status { get; set; }
		public string shippingAddress { get; set; }
		public string cus_id { get; set; }
		public virtual ICollection<OrderDetails>? OrderDetails{ get; set; }

	}
}