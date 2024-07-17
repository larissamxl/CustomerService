using System.ComponentModel.DataAnnotations;

namespace CustomerService.Dtos
{
    public class CustomerCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Score { get; set; }
    }   
}
