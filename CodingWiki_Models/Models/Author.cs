using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Models.Models
{

    [Table("Authors")]
    public class Author
    {
        [Key]
        public int Author_Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Location { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }

        }
        public List<BookAuthorMap> BookAuthorMap { get; set; }

    }
}
