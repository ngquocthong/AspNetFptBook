using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class StoreOwner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string own_username { get; set; }
        public string own_pass { get; set; }
        public string own_name { get; set; }
        public string store_name { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}
