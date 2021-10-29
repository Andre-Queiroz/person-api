using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace person_api.Model
{
    [Table("dbo.Person")]
    public class Person
    {
        [Required]
        public int PersonId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}