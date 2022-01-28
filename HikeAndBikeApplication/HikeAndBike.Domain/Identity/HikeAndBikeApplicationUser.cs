using HikeAndBike.Domain.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBike.Domain.Identity
{
    public class HikeAndBikeApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ShoppingCart UserCart { get; set; }
    }
}
