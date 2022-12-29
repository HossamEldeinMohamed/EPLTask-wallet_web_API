using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.DTO
{
    public class LoginDTO
    {
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
