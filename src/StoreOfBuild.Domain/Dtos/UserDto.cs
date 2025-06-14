using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreOfBuild.Domain.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Password { get; set; }
        

        [Required]
        public string Email { get; set; }
    }
}