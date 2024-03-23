using System.ComponentModel.DataAnnotations;

namespace LearnMVVC.Models.DataModel
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Length(2, 200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Length(2, 200)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateTime Dob { get; set; }

        public string Gender { get; set; } = string.Empty;

        public Boolean IsManager { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
