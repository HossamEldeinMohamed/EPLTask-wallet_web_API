using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccessLayer.Entities
{
    public class Wallet : Entity
    {
        public double Balance { get; set; }

        public string UserId { get; set; } = string.Empty;

        public virtual IdentityUser? User { get; set; }

    }
}
