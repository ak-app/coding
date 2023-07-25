using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}