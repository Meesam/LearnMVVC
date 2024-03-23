using System.ComponentModel.DataAnnotations;

namespace LearnMVVC.Models.DataModel
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
    }
}
