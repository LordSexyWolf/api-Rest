using System.ComponentModel.DataAnnotations;

namespace UserRol.Models{
    public class UserRol{
        
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int RoleId { get; set; }

        [Required]
        public int StatusId { get; set; }

    }
}