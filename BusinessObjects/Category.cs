﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BusinessObjects
{
    public class Category
    {
		

		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        public string cate_name { get; set; }
        public string cate_des { get; set; }
        public Boolean accept { get; set; }
		public string? email_request { get; set; }

		[JsonIgnore]
        public virtual ICollection<Book>? Books { get; set; }
    }
}
