using BusinessObjects;

namespace WebClient.Models
{
    public class CartItem
    {
        public int quantity { get; set; }
        public Book? book { get; set; }
    }
}
