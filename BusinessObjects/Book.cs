using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Xml.Serialization;

namespace BusinessObjects
{
    public class Book
    {
        public Book(int iD, string book_name, string book_description, string book_author, double book_price, int quantity, int cate_id, string book_img)
        {

            this.book_name = book_name;
            this.book_author = book_author;
            this.book_description = book_description;
            this.book_price = book_price;
            this.quantity = quantity;
            this.cate_id = cate_id;
            this.book_img = book_img;
        }
        public Book(int iD, string book_name, string book_description, string book_author, double book_price, int quantity, int cate_id)
        {

            this.book_name = book_name;
            this.book_author = book_author;
            this.book_description = book_description;
            this.book_price = book_price;
            this.quantity = quantity;
            this.cate_id = cate_id;
        }

        public Book()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string book_name { get; set; }
        [Required]
        public string book_author { get; set; }
        [Required]
        public string book_description { get; set; }
        [Required]
        public double book_price { get; set; }
        [Required]
        public int quantity { get; set; }
        public string book_img { get; set; }
        [Required]
        public string owner_id { get; set; }

        public int cate_id { get; set; }

        [NotMapped]
        public IFormFile? imgFile { get; set; }

        [ForeignKey("cate_id")]
      
        public virtual Category? Category { get; set; }

    }
    
}
