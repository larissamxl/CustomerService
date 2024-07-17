using System.ComponentModel.DataAnnotations;

namespace CustomerService.Model
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Score { get; set; }
    }
}
