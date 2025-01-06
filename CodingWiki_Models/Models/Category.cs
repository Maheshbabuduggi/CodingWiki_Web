using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Models.Models
{
    public class Category
    {
        [Key]
        [Column("Category_Id")]
        public int Category_Id {  get; set; }
        public string CategoryName { get; set; }   
    }
}
