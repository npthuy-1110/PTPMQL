using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PROJECT_NAME.Models
{
 [Table ("Persons")]
public class Person
 {
   [Key]
    public required string PersonId { get; set; }
    public required string FullName { get; set; }
    public required string Address { get; set; }
    }
 }