using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuiceBarAPI.Models
{
    public class Customer
    {
        [Key]
        public long CustomerId {  get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string CustomerName { get; set; }
    }
}
