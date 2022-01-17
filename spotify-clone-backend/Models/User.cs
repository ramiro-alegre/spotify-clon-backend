using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace spotify_clone_backend.Models
{
    public class User
    {
        public long Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [DefaultValue("User")]
        public string Role { get; set; }
    }
}
